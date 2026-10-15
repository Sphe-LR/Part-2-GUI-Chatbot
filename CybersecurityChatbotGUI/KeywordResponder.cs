using System;
using System.Collections.Generic;

namespace CybersecurityChatbotGUI
{
    /// <summary>
    /// Recognises cybersecurity keywords in user input and returns
    /// a random response for the matched topic.
    /// Uses Dictionary&lt;string, List&lt;string&gt;&gt; for Part 2's code optimisation requirement.
    /// </summary>
    public class KeywordResponder
    {
        // Dictionary: keyword -> list of possible responses
        private readonly Dictionary<string, List<string>> _topicResponses;

        // One Random instance reused for all random selections.
        private readonly Random _random = new Random();

        // Remembers the last topic that was matched (for "tell me more" support).
        public string LastTopic { get; private set; } = string.Empty;

        public KeywordResponder()
        {
            _topicResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                // ---------- PASSWORD ----------
                ["password"] = new List<string>
                {
                    "Use a strong, unique password for each account - mix upper case, lower case, numbers and symbols.",
                    "Avoid using personal details such as your birth date or pet names in passwords.",
                    "Consider using a trusted password manager to store complex passwords safely.",
                    "Never share your passwords with anyone - not even someone claiming to be tech support."
                },

                // ---------- PHISHING ----------
                ["phishing"] = new List<string>
                {
                    "Always check the sender's email address before clicking links - scammers fake familiar names.",
                    "Look for spelling mistakes and urgent language - common signs of a phishing attempt.",
                    "Never enter your password on a page you reached from an email link.",
                    "Hover over a link to preview the real destination before clicking it."
                },

                // ---------- SCAM ----------
                ["scam"] = new List<string>
                {
                    "If an offer sounds too good to be true, it usually is - slow down before responding.",
                    "Never send money or gift cards to someone you have only met online.",
                    "Scammers create urgency. Take a breath and verify through an official phone number.",
                    "Report scam messages to your bank or the relevant authority immediately."
                },

                // ---------- PRIVACY ----------
                ["privacy"] = new List<string>
                {
                    "Review the privacy settings on your social media accounts regularly.",
                    "Limit the personal information you share publicly online.",
                    "Check which apps have access to your location, camera and microphone.",
                    "Use a VPN on public Wi-Fi to keep your browsing private."
                },

                // ---------- MALWARE ----------
                ["malware"] = new List<string>
                {
                    "Only download software from official, trusted websites.",
                    "Keep your operating system and antivirus software up to date.",
                    "Avoid plugging in unknown USB drives - they can carry malware.",
                    "If your device slows down suddenly, run a full antivirus scan."
                },

                // ---------- SAFE BROWSING ----------
                ["browsing"] = new List<string>
                {
                    "Look for the padlock icon and 'https://' before entering personal information.",
                    "Avoid clicking pop-up adverts - close them safely.",
                    "Keep your browser updated to benefit from the latest security patches.",
                    "Use a reputable ad-blocker to reduce malicious adverts."
                },

                // ---------- TWO-FACTOR AUTHENTICATION ----------
                ["two-factor"] = new List<string>
                {
                    "Enable two-factor authentication wherever possible - it adds a second layer of security.",
                    "Prefer an authentication app over SMS where available.",
                    "Keep your backup codes somewhere safe and offline.",
                    "Two-factor authentication stops most account takeovers, even if your password leaks."
                }
            };
        }

        /// <summary>
        /// Finds the first cybersecurity keyword contained in the user's message.
        /// Returns null if no keyword matched.
        /// </summary>
        public string? DetectTopic(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            foreach (var topic in _topicResponses.Keys)
            {
                if (input.Contains(topic, StringComparison.OrdinalIgnoreCase))
                    return topic;
            }

            // Extra aliases that map to existing topics
            if (input.Contains("passwords", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("passcode", StringComparison.OrdinalIgnoreCase))
                return "password";

            if (input.Contains("phish", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("fake email", StringComparison.OrdinalIgnoreCase))
                return "phishing";

            if (input.Contains("fraud", StringComparison.OrdinalIgnoreCase))
                return "scam";

            if (input.Contains("browse", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("website", StringComparison.OrdinalIgnoreCase))
                return "browsing";

            if (input.Contains("2fa", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("two factor", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("authentication", StringComparison.OrdinalIgnoreCase))
                return "two-factor";

            if (input.Contains("virus", StringComparison.OrdinalIgnoreCase))
                return "malware";

            return null;
        }

        /// <summary>
        /// Returns a random response for the given topic.
        /// Updates LastTopic so "tell me more" can continue the topic.
        /// </summary>
        public string GetRandomResponse(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic) || !_topicResponses.ContainsKey(topic))
                return "I am not sure I understand. Can you try rephrasing or ask me about passwords, phishing, scams or privacy?";

            LastTopic = topic;
            List<string> options = _topicResponses[topic];
            return options[_random.Next(options.Count)];
        }

        /// <summary>
        /// Returns a random tip from the previous topic (used for "tell me more").
        /// </summary>
        public string GetAnotherTip()
        {
            if (string.IsNullOrWhiteSpace(LastTopic))
                return "Please tell me which cybersecurity topic you'd like more on - passwords, phishing, scams or privacy?";

            return GetRandomResponse(LastTopic);
        }

        /// <summary>
        /// Returns true if the message looks like a follow-up request.
        /// </summary>
        public bool IsFollowUp(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return input.Contains("tell me more", StringComparison.OrdinalIgnoreCase)
                || input.Contains("another tip", StringComparison.OrdinalIgnoreCase)
                || input.Contains("more", StringComparison.OrdinalIgnoreCase)
                || input.Contains("explain more", StringComparison.OrdinalIgnoreCase)
                || input.Contains("continue", StringComparison.OrdinalIgnoreCase)
                || input.Contains("what else", StringComparison.OrdinalIgnoreCase)
                || input.Contains("don't understand", StringComparison.OrdinalIgnoreCase)
                || input.Contains("do not understand", StringComparison.OrdinalIgnoreCase);
        }
    }
}