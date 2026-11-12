using System;

namespace CybersecurityChatbotGUI
{
    public class NlpProcessor
    {
        public string DetectIntent(string input)
        {
            string text = input.ToLower();

            if (text.Contains("quiz") || text.Contains("test my knowledge"))
                return "StartQuiz";

            if (text.Contains("show task") || text.Contains("my task") || text.Contains("view task"))
                return "ShowTasks";

            if (text.Contains("add task") || text.Contains("remind me"))
                return "AddTask";

            if (text.Contains("activity") || text.Contains("what have you done"))
                return "ShowActivity";

            return "Chat"; // Default to normal chat
        }

        public string ExtractTaskTitle(string input)
        {
            // A simple extraction: just return the text after "remind me to" or "add task to"
            string lower = input.ToLower();
            if (lower.Contains("remind me to "))
                return input.Substring(lower.IndexOf("remind me to ") + 13).Trim();
            if (lower.Contains("add task to "))
                return input.Substring(lower.IndexOf("add task to ") + 12).Trim();
            if (lower.Contains("add a task to "))
                return input.Substring(lower.IndexOf("add a task to ") + 14).Trim();

            return input;
        }
    }
}