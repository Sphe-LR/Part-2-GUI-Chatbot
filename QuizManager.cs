using System;
using System.Collections.Generic;
namespace CybersecurityChatbotGUI
{
    public class QuizManager
    {
        private readonly List<QuizQuestion> questions;
        public int CurrentIndex { get; private set; }
        public int Score { get; private set; }
        public bool QuizStarted { get; private set; }
        public int TotalQuestions => questions.Count;
        public QuizQuestion CurrentQuestion => questions[CurrentIndex];

        public QuizManager() { questions = BuildQuestions(); }

        public void StartQuiz() { CurrentIndex = 0; Score = 0; QuizStarted = true; }

        public bool CheckAnswer(int selectedIndex)
        {
            bool correct = selectedIndex == CurrentQuestion.CorrectOptionIndex;
            if (correct) Score++;
            return correct;
        }

        public bool MoveNext()
        {
            if (CurrentIndex < questions.Count - 1) { CurrentIndex++; return true; }
            QuizStarted = false; return false;
        }

        private List<QuizQuestion> BuildQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion { QuestionText = "An unexpected email asks for your password. What should you do?", Options = new List<string> { "Reply with the password", "Click the link", "Report it as phishing", "Ignore it" }, CorrectOptionIndex = 2, Explanation = "Legitimate organisations should not ask for passwords by email." },
                new QuizQuestion { QuestionText = "Which password practice is safer?", Options = new List<string> { "Using '123456'", "Using the same password everywhere", "Using a unique password for each account", "Using your birthdate" }, CorrectOptionIndex = 2, Explanation = "Unique passwords prevent one breach from compromising all your accounts." },
                new QuizQuestion { QuestionText = "What does HTTPS mean in a website URL?", Options = new List<string> { "The site is free", "The connection is encrypted", "The site is government-owned", "The site is fast" }, CorrectOptionIndex = 1, Explanation = "HTTPS means the data sent between you and the site is encrypted." },
                new QuizQuestion { QuestionText = "True or False: Public Wi-Fi is always safe for banking.", Options = new List<string> { "True", "False" }, CorrectOptionIndex = 1, Explanation = "Public Wi-Fi is often unencrypted and can be monitored by hackers." },
                new QuizQuestion { QuestionText = "What is two-factor authentication (2FA)?", Options = new List<string> { "Using two passwords", "A second layer of security like a code sent to your phone", "Logging in twice", "A type of antivirus" }, CorrectOptionIndex = 1, Explanation = "2FA adds a second step to verify your identity." }
            };
        }
    }
}