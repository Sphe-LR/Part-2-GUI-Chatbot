using System;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityChatbotGUI
{
    public partial class ChatbotForm : Form
    {
        private ChatBot _chatBot = new ChatBot();
        private bool _voicePlayed = false;
        private TaskRepository taskRepo = new TaskRepository();
        private NlpProcessor nlp = new NlpProcessor();

        private QuizManager quizManager = new QuizManager();
        private ActivityLogger activityLogger = new ActivityLogger();

        public ChatbotForm()
        {
            InitializeComponent();
            _chatBot.ResponseHandler = AppendBotMessage;
        }

        private void ChatbotForm_Load(object sender, EventArgs e)
        {
            ShowBanner();
            AppendBotMessage("Welcome! I'm your Cybersecurity Awareness Assistant.");
            AppendBotMessage("Try asking about passwords, or say 'start the quiz' or 'remind me to check privacy'.");

            txtUserInput.Focus();

            if (!_voicePlayed)
            {
                _voicePlayed = true;
                this.BeginInvoke(new Action(() => _chatBot.PlayVoiceGreeting()));
            }

            LoadTasks();
            DisplayRecentActivity(5);
        }

        // ==========================================
        // CHAT AND NLP INTEGRATION
        // ==========================================

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SendUserMessage();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtUserInput.Focused)
            {
                SendUserMessage();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SendUserMessage()
        {
            string userInput = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please type a question first.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AppendUserMessage(userInput);
            txtUserInput.Clear();

            if (_chatBot.IsExitCommand(userInput))
            {
                Application.Exit();
                return;
            }

            string intent = nlp.DetectIntent(userInput);

            if (intent == "StartQuiz")
            {
                tabMain.SelectedTab = tabPage3;
                AppendBotMessage("I've opened the Cyber Quiz tab. Click 'Start Quiz'!");
                return;
            }
            else if (intent == "ShowTasks")
            {
                tabMain.SelectedTab = tabPage2;
                LoadTasks();
                AppendBotMessage("Here are your tasks.");
                return;
            }
            else if (intent == "AddTask")
            {
                string title = nlp.ExtractTaskTitle(userInput);
                CyberTask newTask = new CyberTask { Title = title, Description = "Created via chatbot", IsCompleted = false };
                try
                {
                    taskRepo.AddTask(newTask);
                    activityLogger.Log("Task added via chat: " + title);
                    AppendBotMessage($"I've added a task: '{title}'.");
                    tabMain.SelectedTab = tabPage2;
                    LoadTasks();
                }
                catch (Exception ex) { AppendBotMessage("Error: " + ex.Message); }
                return;
            }
            else if (intent == "ShowActivity")
            {
                tabMain.SelectedTab = tabPage4;
                DisplayRecentActivity(10);
                AppendBotMessage("Here is your Activity Log.");
                return;
            }

            // Default Chatbot Response
            string response = _chatBot.ProcessInput(userInput);
            AppendBotMessage(response);
            lblBotStatus.Text = "Type your next question.";
        }

        private void ShowBanner()
        {
            string banner =
                "     ██████╗██╗   ██╗██████╗ ███████╗██████╗ \n" +
                "    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗\n" +
                "    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝\n" +
                "    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗\n" +
                "    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║\n" +
                "     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝\n" +
                "        CYBERSECURITY AWARENESS BOT\n" +
                "        Stay Safe Online - Think Before You Click";
            try { txtBanner.Text = banner; } catch { }
        }

        private void AppendUserMessage(string message)
        {
            rtbChatBox.SelectionStart = rtbChatBox.TextLength;
            rtbChatBox.SelectionColor = Color.LightSkyBlue;
            rtbChatBox.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            rtbChatBox.AppendText($"You: {message}{Environment.NewLine}");
            rtbChatBox.SelectionColor = rtbChatBox.ForeColor;
            rtbChatBox.ScrollToCaret();
        }

        private void AppendBotMessage(string message)
        {
            if (rtbChatBox.InvokeRequired)
            {
                rtbChatBox.Invoke(new Action<string>(AppendBotMessage), message);
                return;
            }
            rtbChatBox.SelectionStart = rtbChatBox.TextLength;
            rtbChatBox.SelectionColor = Color.LightGreen;
            rtbChatBox.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbChatBox.AppendText($"Bot: {message}{Environment.NewLine}{Environment.NewLine}");
            rtbChatBox.SelectionColor = rtbChatBox.ForeColor;
            rtbChatBox.ScrollToCaret();
        }

        // ==========================================
        // TASK ASSISTANT DATABASE
        // ==========================================
        private void AddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskName.Text)) return;

            CyberTask newTask = new CyberTask
            {
                Title = txtTaskName.Text,
                Description = txtTaskDescription.Text,
                ReminderDate = chkUseReminder.Checked ? dtpReminder.Value : (DateTime?)null,
                IsCompleted = false
            };

            try
            {
                taskRepo.AddTask(newTask);
                activityLogger.Log("Task added: " + newTask.Title);
                MessageBox.Show("Task added!");
                txtTaskName.Clear();
                txtTaskDescription.Clear();
                LoadTasks();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnRefreshTasks_Click(object sender, EventArgs e) => LoadTasks();

        private void LoadTasks()
        {
            try
            {
                dgvTask.DataSource = null;
                dgvTask.DataSource = taskRepo.GetAllTasks();
            }
            catch (Exception ex) { MessageBox.Show("Error loading tasks: " + ex.Message); }
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            CyberTask task = dgvTask.CurrentRow?.DataBoundItem as CyberTask;
            if (task == null) return;
            try
            {
                taskRepo.MarkTaskCompleted(task.TaskId);
                activityLogger.Log("Task completed: " + task.Title);
                LoadTasks();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            CyberTask task = dgvTask.CurrentRow?.DataBoundItem as CyberTask;
            if (task == null) return;
            if (MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    taskRepo.DeleteTask(task.TaskId);
                    activityLogger.Log("Task deleted: " + task.Title);
                    LoadTasks();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // ==========================================
        // CYBER QUIZ LOGIC
        // ==========================================
        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            quizManager.StartQuiz();
            activityLogger.Log("Started Cyber Quiz");
            btnSubmitAnswer.Enabled = true;
            btnNextQuestion.Enabled = false;
            lblQuizFeedback.Text = "";
            DisplayCurrentQuestion();
        }

        private void DisplayCurrentQuestion()
        {
            var q = quizManager.CurrentQuestion;
            lblQuestionNumber.Text = $"Question {quizManager.CurrentIndex + 1} of {quizManager.TotalQuestions}";
            lblQuestion.Text = q.QuestionText;

            rdoA.Text = q.Options[0]; rdoA.Checked = false; rdoA.Visible = true;
            rdoB.Text = q.Options[1]; rdoB.Checked = false; rdoB.Visible = true;

            if (q.Options.Count > 2) { rdoC.Text = q.Options[2]; rdoC.Checked = false; rdoC.Visible = true; }
            else rdoC.Visible = false;

            if (q.Options.Count > 3) { rdoD.Text = q.Options[3]; rdoD.Checked = false; rdoD.Visible = true; }
            else rdoD.Visible = false;

            lblQuizScore.Text = $"Score: {quizManager.Score}/{quizManager.TotalQuestions}";
        }

        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            int selected = rdoA.Checked ? 0 : rdoB.Checked ? 1 : rdoC.Checked ? 2 : rdoD.Checked ? 3 : -1;
            if (selected == -1) { lblQuizFeedback.Text = "Please select an answer."; return; }

            bool correct = quizManager.CheckAnswer(selected);
            lblQuizFeedback.Text = (correct ? "Correct! " : "Incorrect. ") + quizManager.CurrentQuestion.Explanation;
            lblQuizScore.Text = $"Score: {quizManager.Score}/{quizManager.TotalQuestions}";

            btnSubmitAnswer.Enabled = false;
            btnNextQuestion.Enabled = true;
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (quizManager.MoveNext())
            {
                lblQuizFeedback.Text = "";
                btnSubmitAnswer.Enabled = true;
                btnNextQuestion.Enabled = false;
                DisplayCurrentQuestion();
            }
            else
            {
                lblQuizFeedback.Text = $"Quiz Complete! Final Score: {quizManager.Score}/{quizManager.TotalQuestions}";
                btnSubmitAnswer.Enabled = false;
                btnNextQuestion.Enabled = false;
                activityLogger.Log($"Finished Quiz - Score {quizManager.Score}");
            }
        }

        // ==========================================
        // ACTIVITY LOG
        // ==========================================
        private void DisplayRecentActivity(int count)
        {
            lstActivity.Items.Clear();
            var recent = activityLogger.GetRecent(count);
            if (recent.Count == 0) { lstActivity.Items.Add("No activity yet."); return; }
            foreach (var log in recent) lstActivity.Items.Add(log);
        }

        private void btnRefreshActivity_Click(object sender, EventArgs e) => DisplayRecentActivity(5);
        private void btnShowMore_Click(object sender, EventArgs e) => DisplayRecentActivity(10);
    }
}