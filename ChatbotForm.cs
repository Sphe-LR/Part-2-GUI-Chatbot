using System;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityChatbotGUI
{
    public partial class ChatbotForm : Form
    {
        private ChatBot _chatBot = new ChatBot();
        private bool _voicePlayed = false;

        public ChatbotForm()
        {
            InitializeComponent();
            _chatBot.ResponseHandler = AppendBotMessage;
        }

        // ================================================================
        // FORM LOAD - runs when window first opens
        // ================================================================
        private void ChatbotForm_Load(object sender, EventArgs e)
        {
            ShowBanner();

            // Welcome messages
            AppendBotMessage("Welcome! I'm your Cybersecurity Awareness Assistant. 👋");
            AppendBotMessage("My name is Cyra, and I'm here to help you stay safe online.");

            // Topic menu - shows the user what they can ask
            AppendBotMessage(
                "Here are some topics you can ask me about:\n" +
                "     🔑  password safety\n" +
                "     🎣  phishing\n" +
                "     💰  scams\n" +
                "     🔒  privacy\n" +
                "     🦠  malware\n" +
                "     🌐  safe browsing\n" +
                "     🔐  two-factor authentication"
            );

            // How to use
            AppendBotMessage(
                "You can:\n" +
                "     • Type a topic (e.g., \"phishing\")\n" +
                "     • Ask a question (e.g., \"Tell me about passwords\")\n" +
                "     • Say \"tell me more\" for another tip\n" +
                "     • Say \"I'm interested in privacy\" so I remember your favourite topic\n" +
                "     • Type \"exit\", \"bye\" or \"quit\" when you're done"
            );

            // Ask for name
            AppendBotMessage("What's your name? (Say: \"My name is ...\")");

            // Focus input
            txtUserInput.Focus();

            // Play voice greeting after form is visible
            if (!_voicePlayed)
            {
                _voicePlayed = true;
                this.BeginInvoke(new Action(() =>
                {
                    _chatBot.PlayVoiceGreeting();
                }));
            }
        }

        // ================================================================
        // SEND BUTTON
        // ================================================================
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendUserMessage();
        }

        // ================================================================
        // ENTER KEY - also sends the message
        // ================================================================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtUserInput.Focused)
            {
                SendUserMessage();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ================================================================
        // CORE LOGIC - process user message
        // ================================================================
        private void SendUserMessage()
        {
            string userInput = txtUserInput.Text.Trim();

            // Validation - blank input
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show(
                    "Please type a question or cybersecurity topic first.",
                    "Empty Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                txtUserInput.Focus();
                return;
            }

            // Show the user's message
            AppendUserMessage(userInput);
            txtUserInput.Clear();

            // ---------- CHECK FOR EXIT COMMAND ----------
            if (_chatBot.IsExitCommand(userInput))
            {
                AppendBotMessage("Goodbye! Stay safe online. 👋");
                MessageBox.Show(
                    "Thank you for using the Cybersecurity Awareness Bot!\n\nStay safe online! 👋",
                    "Goodbye",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                Application.Exit();
                return;
            }

            // Get response from chatbot logic
            string response;
            try
            {
                response = _chatBot.ProcessInput(userInput);
            }
            catch (Exception ex)
            {
                response = $"Sorry, something went wrong: {ex.Message}";
            }

            // Show response
            AppendBotMessage(response);
            lblStatus.Text = "Type your next question or say 'tell me more'.";
            txtUserInput.Focus();
        }

        // ================================================================
        // UI HELPERS
        // ================================================================

        private void ShowBanner()
        {
            string banner =
                "     ██████╗██╗   ██╗██████╗ ███████╗██████╗ \n" +
                "    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗\n" +
                "    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝\n" +
                "    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗\n" +
                "    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║\n" +
                "     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝\n" +
                "        🔐 CYBERSECURITY AWARENESS BOT 🔐\n" +
                "        Stay Safe Online • Think Before You Click";

            txtBanner.Text = banner;
        }

        private void AppendUserMessage(string message)
        {
            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.SelectionLength = 0;

            rtbChatHistory.SelectionColor = Color.LightSkyBlue;
            rtbChatHistory.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            rtbChatHistory.AppendText($"You: {message}{Environment.NewLine}");

            rtbChatHistory.SelectionColor = rtbChatHistory.ForeColor;
            rtbChatHistory.ScrollToCaret();
        }

        private void AppendBotMessage(string message)
        {
            if (rtbChatHistory.InvokeRequired)
            {
                rtbChatHistory.Invoke(new Action<string>(AppendBotMessage), message);
                return;
            }

            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.SelectionLength = 0;

            rtbChatHistory.SelectionColor = Color.LightGreen;
            rtbChatHistory.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbChatHistory.AppendText($"Bot: {message}{Environment.NewLine}{Environment.NewLine}");

            rtbChatHistory.SelectionColor = rtbChatHistory.ForeColor;
            rtbChatHistory.ScrollToCaret();
        }
    }
}