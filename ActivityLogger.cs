using System;
using System.Collections.Generic;
namespace CybersecurityChatbotGUI
{
    public class ActivityLogger
    {
        private readonly List<string> logs = new List<string>();
        public void Log(string action) { logs.Insert(0, $"[{DateTime.Now:HH:mm}] {action}"); }
        public List<string> GetRecent(int count) { return logs.GetRange(0, Math.Min(count, logs.Count)); }
    }
}