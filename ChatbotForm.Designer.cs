namespace CybersecurityChatbotGUI
{
    partial class ChatbotForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtBanner = new System.Windows.Forms.RichTextBox();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(20, 30, 48);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔐  CYBERSECURITY AWARENESS BOT  🔐";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // txtBanner
            this.txtBanner.BackColor = System.Drawing.Color.FromArgb(15, 15, 30);
            this.txtBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBanner.Font = new System.Drawing.Font("Consolas", 8F);
            this.txtBanner.ForeColor = System.Drawing.Color.Cyan;
            this.txtBanner.Location = new System.Drawing.Point(12, 55);
            this.txtBanner.Name = "txtBanner";
            this.txtBanner.ReadOnly = true;
            this.txtBanner.Size = new System.Drawing.Size(760, 120);
            this.txtBanner.TabIndex = 1;
            this.txtBanner.Text = "";

            // rtbChatHistory
            this.rtbChatHistory.BackColor = System.Drawing.Color.FromArgb(25, 25, 40);
            this.rtbChatHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbChatHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbChatHistory.ForeColor = System.Drawing.Color.White;
            this.rtbChatHistory.Location = new System.Drawing.Point(12, 185);
            this.rtbChatHistory.Name = "rtbChatHistory";
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.Size = new System.Drawing.Size(760, 340);
            this.rtbChatHistory.TabIndex = 2;
            this.rtbChatHistory.Text = "";

            // txtUserInput
            this.txtUserInput.BackColor = System.Drawing.Color.White;
            this.txtUserInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserInput.Location = new System.Drawing.Point(12, 535);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(650, 32);
            this.txtUserInput.TabIndex = 3;

            // btnSend
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(0, 180, 180);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(672, 533);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 36);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // lblStatus
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(12, 578);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(760, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Ask me about passwords, phishing, scams, privacy, malware, safe browsing or two-factor authentication.";

            // ChatbotForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(20, 30, 48);
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.rtbChatHistory);
            this.Controls.Add(this.txtBanner);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChatbotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cybersecurity Awareness Bot";
            this.Load += new System.EventHandler(this.ChatbotForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox txtBanner;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblStatus;
    }
}