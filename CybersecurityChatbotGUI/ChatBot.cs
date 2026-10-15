using System;

namespace CybersecurityChatbotGUI
{
    /// <summary>
    /// Delegate used to send the chatbot's response back to the UI.
    /// Satisfies the Part 2 requirement to use delegates.
    /// </summary>
    public delegate void BotResponseHandler(string message);

    /// <summary>
    /// Main coordinator that ties together KeywordResponder, SentimentDetector,
    /// MemoryStore and VoiceGreeting. Receives user input and produces the
    /// final response, invoking the delegate to send it to the UI.
    /// </summary>
    public class ChatBot
    {
        // ----- Services used by the chatbot -----
        private readonly KeywordResponder _keywordResponder;
        private readonly SentimentDetector _sentimentDetector;
        private readonly MemoryStore _memory;
        private readonly VoiceGreeting _voice;

        // ----- Delegate used to send messages to the UI -----
        public BotResponseHandler? ResponseHandler;

        /// <summary>
        /// Creates the chatbot and all its dependencies.
        /// </summary>
        public ChatBot()
        {
            _keywordResponder = new KeywordResponder();
            _sentimentDetector = new SentimentDetector();
            _memory = new MemoryStore();
            _voice = new VoiceGreeting();
        }

        /// <summary>
        /// Plays the voice greeting when the GUI opens.
        /// </summary>
        public void PlayVoiceGreeting()
        {
            _voice.PlayGreeting();
        }

        /// <summary>
        /// Returns true if the chatbot has remembered the user's name.
        /// </summary>
        public bool HasUserName()
        {
            return _memory.HasUserName();
        }

        /// <summary>
        /// Returns true if the user's message is an exit command.
        /// Recognises common ways to close the chatbot.
        /// </summary>
        public bool IsExitCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string text = input.Trim().ToLower();
            return text == "exit"
                || text == "quit"
                || text == "bye"
                || text == "goodbye"
                || text == "close"
                || text == "end";
        }

        /// <summary>
        /// Stores the user's name in memory and returns a personal greeting.
        /// </summary>
        public string SetUserName(string name)
        {
            _memory.UserName = name.Trim();
            return $"Nice to meet you, {_memory.UserName}! I'm your Cybersecurity Awareness Assistant.";
        }

        /// <summary>
        /// Processes a user message and returns the chatbot's response.
        /// Order of checks:
        /// 1. Validate input
        /// 2. Detect sentiment
        /// 3. Detect interest ("I'm interested in X")
        /// 4. Detect name ("My name is X")
        /// 5. Follow-up request ("tell me more")
        /// 6. Cybersecurity topic
        /// 7. Unknown fallback
        /// </summary>
        public string ProcessInput(string userInput)
        {
            // 1. Validate input
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please type a question or cybersecurity topic first.";

            string trimmed = userInput.Trim();

            // 2. Detect sentiment
            Sentiment sentiment = _sentimentDetector.Detect(trimmed);
            string empathy = _sentimentDetector.GetEmpathyOpening(sentiment);

            // 3. Interest: "I'm interested in privacy"
            string? interestTopic = ExtractInterest(trimmed);
            if (interestTopic != null)
            {
                _memory.FavouriteTopic = interestTopic;
                string response = _keywordResponder.GetRandomResponse(interestTopic);
                return $"{empathy}Great! I'll remember that you're interested in {interestTopic}. {response}";
            }

            // 4. Name: "My name is Siphesihle"
            string? detectedName = ExtractName(trimmed);
            if (detectedName != null && !_memory.HasUserName())
            {
                _memory.UserName = detectedName;
                return $"{empathy}Nice to meet you, {detectedName}! Ask me about any cybersecurity topic.";
            }

            // 5. Follow-up: "tell me more"
            if (_keywordResponder.IsFollowUp(trimmed))
            {
                string anotherTip = _keywordResponder.GetAnotherTip();
                return BuildResponse(empathy, anotherTip);
            }

            // 6. Cybersecurity topic
            string? topic = _keywordResponder.DetectTopic(trimmed);
            if (topic != null)
            {
                _memory.CurrentTopic = topic;
                string tip = _keywordResponder.GetRandomResponse(topic);
                string personalisation = BuildPersonalisation(topic);
                return BuildResponse(empathy, tip + personalisation);
            }

            // 7. Unknown input fallback
            return $"{empathy}I'm not sure I understand. Can you try rephrasing? " +
                   "You can ask me about passwords, phishing, scams, privacy, malware, safe browsing or two-factor authentication.";
        }

        /// <summary>
        /// Sends a response via the delegate.
        /// </summary>
        public void SendResponse(string message)
        {
            ResponseHandler?.Invoke(message);
        }

        // ================================================================
        // PRIVATE HELPERS
        // ================================================================

        private string BuildResponse(string empathy, string core)
        {
            string greeting = _memory.HasUserName() ? $"{_memory.UserName}, " : string.Empty;
            return $"{greeting}{empathy}{core}";
        }

        private string BuildPersonalisation(string currentTopic)
        {
            if (!_memory.HasFavouriteTopic())
                return string.Empty;

            if (string.Equals(_memory.FavouriteTopic, currentTopic, StringComparison.OrdinalIgnoreCase))
                return string.Empty;

            return $" Since you're interested in {_memory.FavouriteTopic}, you might also want to look into that area.";
        }

        private string? ExtractInterest(string input)
        {
            string[] markers = { "interested in ", "i like ", "my favourite is ", "my favorite is " };

            foreach (string marker in markers)
            {
                int index = input.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    string after = input.Substring(index + marker.Length).Trim();
                    string firstWord = after.Split(' ', ',', '.', '!', '?')[0];
                    string? topic = _keywordResponder.DetectTopic(firstWord);
                    if (topic != null)
                        return topic;
                }
            }
            return null;
        }

        private string? ExtractName(string input)
        {
            string[] markers = { "my name is ", "call me " };

            foreach (string marker in markers)
            {
                int index = input.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    string after = input.Substring(index + marker.Length).Trim();
                    string firstWord = after.Split(' ', ',', '.', '!', '?')[0];
                    if (!string.IsNullOrWhiteSpace(firstWord) && firstWord.Length <= 30)
                        return firstWord;
                }
            }
            return null;
        }
    }
}