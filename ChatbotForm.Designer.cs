namespace CybersecurityChatbotGUI
{
    partial class ChatbotForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbChatBox = new System.Windows.Forms.RichTextBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblBotStatus = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.chkUseReminder = new System.Windows.Forms.CheckBox();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.AddTask = new System.Windows.Forms.Button();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.btnCompleteTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnRefreshTasks = new System.Windows.Forms.Button();
            this.lblTaskStatus = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoC = new System.Windows.Forms.RadioButton();
            this.rdoD = new System.Windows.Forms.RadioButton();
            this.btnStartQuiz = new System.Windows.Forms.Button();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.btnNextQuestion = new System.Windows.Forms.Button();
            this.lblQuizFeedback = new System.Windows.Forms.Label();
            this.lblQuizScore = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lstActivity = new System.Windows.Forms.ListBox();
            this.btnRefreshActivity = new System.Windows.Forms.Button();
            this.btnShowMore = new System.Windows.Forms.Button();
            this.txtBanner = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabMain.Location = new System.Drawing.Point(0, 190);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(800, 410);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbChatBox);
            this.tabPage1.Controls.Add(this.txtUserInput);
            this.tabPage1.Controls.Add(this.btnSubmit);
            this.tabPage1.Controls.Add(this.lblBotStatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(792, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbChatBox
            // 
            this.rtbChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.rtbChatBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbChatBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbChatBox.ForeColor = System.Drawing.Color.White;
            this.rtbChatBox.Location = new System.Drawing.Point(0, 0);
            this.rtbChatBox.Name = "rtbChatBox";
            this.rtbChatBox.ReadOnly = true;
            this.rtbChatBox.Size = new System.Drawing.Size(792, 280);
            this.rtbChatBox.TabIndex = 0;
            this.rtbChatBox.Text = "";
            // 
            // txtUserInput
            // 
            this.txtUserInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserInput.Location = new System.Drawing.Point(8, 295);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(640, 32);
            this.txtUserInput.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(660, 293);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 36);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "SEND";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblBotStatus
            // 
            this.lblBotStatus.AutoSize = true;
            this.lblBotStatus.Location = new System.Drawing.Point(8, 340);
            this.lblBotStatus.Name = "lblBotStatus";
            this.lblBotStatus.Size = new System.Drawing.Size(80, 15);
            this.lblBotStatus.TabIndex = 3;
            this.lblBotStatus.Text = "Status: Ready";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblTaskStatus);
            this.tabPage2.Controls.Add(this.btnRefreshTasks);
            this.tabPage2.Controls.Add(this.btnDeleteTask);
            this.tabPage2.Controls.Add(this.btnCompleteTask);
            this.tabPage2.Controls.Add(this.dgvTask);
            this.tabPage2.Controls.Add(this.AddTask);
            this.tabPage2.Controls.Add(this.dtpReminder);
            this.tabPage2.Controls.Add(this.chkUseReminder);
            this.tabPage2.Controls.Add(this.txtTaskDescription);
            this.tabPage2.Controls.Add(this.txtTaskName);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Task";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(20, 20);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(200, 23);
            this.txtTaskName.TabIndex = 0;
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(20, 60);
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(200, 23);
            this.txtTaskDescription.TabIndex = 1;
            // 
            // chkUseReminder
            // 
            this.chkUseReminder.AutoSize = true;
            this.chkUseReminder.Location = new System.Drawing.Point(20, 100);
            this.chkUseReminder.Name = "chkUseReminder";
            this.chkUseReminder.Size = new System.Drawing.Size(100, 19);
            this.chkUseReminder.TabIndex = 2;
            this.chkUseReminder.Text = "Set Reminder";
            // 
            // dtpReminder
            // 
            this.dtpReminder.Location = new System.Drawing.Point(20, 130);
            this.dtpReminder.Name = "dtpReminder";
            this.dtpReminder.Size = new System.Drawing.Size(200, 23);
            this.dtpReminder.TabIndex = 3;
            // 
            // AddTask
            // 
            this.AddTask.Location = new System.Drawing.Point(20, 170);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(100, 30);
            this.AddTask.TabIndex = 4;
            this.AddTask.Text = "Add Task";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // dgvTask
            // 
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Location = new System.Drawing.Point(250, 20);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.Size = new System.Drawing.Size(520, 250);
            this.dgvTask.TabIndex = 5;
            // 
            // btnCompleteTask
            // 
            this.btnCompleteTask.Location = new System.Drawing.Point(250, 280);
            this.btnCompleteTask.Name = "btnCompleteTask";
            this.btnCompleteTask.Size = new System.Drawing.Size(100, 30);
            this.btnCompleteTask.TabIndex = 6;
            this.btnCompleteTask.Text = "Complete";
            this.btnCompleteTask.Click += new System.EventHandler(this.btnCompleteTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(360, 280);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteTask.TabIndex = 7;
            this.btnDeleteTask.Text = "Delete";
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnRefreshTasks
            // 
            this.btnRefreshTasks.Location = new System.Drawing.Point(470, 280);
            this.btnRefreshTasks.Name = "btnRefreshTasks";
            this.btnRefreshTasks.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshTasks.TabIndex = 8;
            this.btnRefreshTasks.Text = "Refresh";
            this.btnRefreshTasks.Click += new System.EventHandler(this.btnRefreshTasks_Click);
            // 
            // lblTaskStatus
            // 
            this.lblTaskStatus.AutoSize = true;
            this.lblTaskStatus.Location = new System.Drawing.Point(250, 320);
            this.lblTaskStatus.Name = "lblTaskStatus";
            this.lblTaskStatus.Size = new System.Drawing.Size(80, 15);
            this.lblTaskStatus.TabIndex = 9;
            this.lblTaskStatus.Text = "Status: Ready";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblQuizScore);
            this.tabPage3.Controls.Add(this.lblQuizFeedback);
            this.tabPage3.Controls.Add(this.btnNextQuestion);
            this.tabPage3.Controls.Add(this.btnSubmitAnswer);
            this.tabPage3.Controls.Add(this.btnStartQuiz);
            this.tabPage3.Controls.Add(this.rdoD);
            this.tabPage3.Controls.Add(this.rdoC);
            this.tabPage3.Controls.Add(this.rdoB);
            this.tabPage3.Controls.Add(this.rdoA);
            this.tabPage3.Controls.Add(this.lblQuestion);
            this.tabPage3.Controls.Add(this.lblQuestionNumber);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 382);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cyber Quiz";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Location = new System.Drawing.Point(20, 20);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(93, 15);
            this.lblQuestionNumber.TabIndex = 0;
            this.lblQuestionNumber.Text = "Question 1 of 5";
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(20, 45);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(740, 60);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Click 'Start Quiz' to begin!";
            // 
            // rdoA
            // 
            this.rdoA.AutoSize = true;
            this.rdoA.Location = new System.Drawing.Point(20, 120);
            this.rdoA.Name = "rdoA";
            this.rdoA.Size = new System.Drawing.Size(85, 19);
            this.rdoA.TabIndex = 2;
            // 
            // rdoB
            // 
            this.rdoB.AutoSize = true;
            this.rdoB.Location = new System.Drawing.Point(20, 150);
            this.rdoB.Name = "rdoB";
            this.rdoB.Size = new System.Drawing.Size(85, 19);
            this.rdoB.TabIndex = 3;
            // 
            // rdoC
            // 
            this.rdoC.AutoSize = true;
            this.rdoC.Location = new System.Drawing.Point(20, 180);
            this.rdoC.Name = "rdoC";
            this.rdoC.Size = new System.Drawing.Size(85, 19);
            this.rdoC.TabIndex = 4;
            // 
            // rdoD
            // 
            this.rdoD.AutoSize = true;
            this.rdoD.Location = new System.Drawing.Point(20, 210);
            this.rdoD.Name = "rdoD";
            this.rdoD.Size = new System.Drawing.Size(85, 19);
            this.rdoD.TabIndex = 5;
            // 
            // btnStartQuiz
            // 
            this.btnStartQuiz.Location = new System.Drawing.Point(20, 260);
            this.btnStartQuiz.Name = "btnStartQuiz";
            this.btnStartQuiz.Size = new System.Drawing.Size(100, 30);
            this.btnStartQuiz.TabIndex = 6;
            this.btnStartQuiz.Text = "Start Quiz";
            this.btnStartQuiz.Click += new System.EventHandler(this.btnStartQuiz_Click);
            // 
            // btnSubmitAnswer
            // 
            this.btnSubmitAnswer.Location = new System.Drawing.Point(130, 260);
            this.btnSubmitAnswer.Name = "btnSubmitAnswer";
            this.btnSubmitAnswer.Size = new System.Drawing.Size(120, 30);
            this.btnSubmitAnswer.TabIndex = 7;
            this.btnSubmitAnswer.Text = "Submit Answer";
            this.btnSubmitAnswer.Click += new System.EventHandler(this.btnSubmitAnswer_Click);
            // 
            // btnNextQuestion
            // 
            this.btnNextQuestion.Location = new System.Drawing.Point(260, 260);
            this.btnNextQuestion.Name = "btnNextQuestion";
            this.btnNextQuestion.Size = new System.Drawing.Size(120, 30);
            this.btnNextQuestion.TabIndex = 8;
            this.btnNextQuestion.Text = "Next Question";
            this.btnNextQuestion.Click += new System.EventHandler(this.btnNextQuestion_Click);
            // 
            // lblQuizFeedback
            // 
            this.lblQuizFeedback.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblQuizFeedback.Location = new System.Drawing.Point(20, 310);
            this.lblQuizFeedback.Name = "lblQuizFeedback";
            this.lblQuizFeedback.Size = new System.Drawing.Size(740, 40);
            this.lblQuizFeedback.TabIndex = 9;
            // 
            // lblQuizScore
            // 
            this.lblQuizScore.AutoSize = true;
            this.lblQuizScore.Location = new System.Drawing.Point(650, 20);
            this.lblQuizScore.Name = "lblQuizScore";
            this.lblQuizScore.Size = new System.Drawing.Size(64, 15);
            this.lblQuizScore.TabIndex = 10;
            this.lblQuizScore.Text = "Score: 0/5";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnShowMore);
            this.tabPage4.Controls.Add(this.btnRefreshActivity);
            this.tabPage4.Controls.Add(this.lstActivity);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(792, 382);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Activity Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lstActivity
            // 
            this.lstActivity.FormattingEnabled = true;
            this.lstActivity.ItemHeight = 15;
            this.lstActivity.Location = new System.Drawing.Point(20, 20);
            this.lstActivity.Name = "lstActivity";
            this.lstActivity.Size = new System.Drawing.Size(750, 259);
            this.lstActivity.TabIndex = 0;
            // 
            // btnRefreshActivity
            // 
            this.btnRefreshActivity.Location = new System.Drawing.Point(20, 300);
            this.btnRefreshActivity.Name = "btnRefreshActivity";
            this.btnRefreshActivity.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshActivity.TabIndex = 1;
            this.btnRefreshActivity.Text = "Refresh";
            this.btnRefreshActivity.Click += new System.EventHandler(this.btnRefreshActivity_Click);
            // 
            // btnShowMore
            // 
            this.btnShowMore.Location = new System.Drawing.Point(130, 300);
            this.btnShowMore.Name = "btnShowMore";
            this.btnShowMore.Size = new System.Drawing.Size(100, 30);
            this.btnShowMore.TabIndex = 2;
            this.btnShowMore.Text = "Show More";
            this.btnShowMore.Click += new System.EventHandler(this.btnShowMore_Click);
            // 
            // txtBanner
            // 
            this.txtBanner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBanner.Font = new System.Drawing.Font("Consolas", 8F);
            this.txtBanner.Location = new System.Drawing.Point(12, 60);
            this.txtBanner.Name = "txtBanner";
            this.txtBanner.ReadOnly = true;
            this.txtBanner.Size = new System.Drawing.Size(760, 120);
            this.txtBanner.TabIndex = 1;
            this.txtBanner.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "CYBERSECURITY AWARENESS BOT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChatbotForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBanner);
            this.Controls.Add(this.tabMain);
            this.Name = "ChatbotForm";
            this.Text = "Cybersecurity Awareness Bot";
            this.Load += new System.EventHandler(this.ChatbotForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtbChatBox;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblBotStatus;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.TextBox txtTaskDescription;
        private System.Windows.Forms.CheckBox chkUseReminder;
        private System.Windows.Forms.DateTimePicker dtpReminder;
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.Button btnCompleteTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnRefreshTasks;
        private System.Windows.Forms.Label lblTaskStatus;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoC;
        private System.Windows.Forms.RadioButton rdoD;
        private System.Windows.Forms.Button btnStartQuiz;
        private System.Windows.Forms.Button btnSubmitAnswer;
        private System.Windows.Forms.Button btnNextQuestion;
        private System.Windows.Forms.Label lblQuizFeedback;
        private System.Windows.Forms.Label lblQuizScore;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lstActivity;
        private System.Windows.Forms.Button btnRefreshActivity;
        private System.Windows.Forms.Button btnShowMore;
        private System.Windows.Forms.RichTextBox txtBanner;
        private System.Windows.Forms.Label lblTitle;
    }
}