using System;

namespace CybersecurityChatbotGUI
{
    /// <summary>
    /// Possible sentiment values the chatbot can detect.
    /// </summary>
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated
    }

    /// <summary>
    /// Detects simple sentiment from the user's message.
    /// Supports Part 2's sentiment detection requirement.
    /// </summary>
    public class SentimentDetector
    {
        /// <summary>
        /// Reads the user's message and returns a matching Sentiment.
        /// Default is Neutral if no emotional word is found.
        /// </summary>
        public Sentiment Detect(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Sentiment.Neutral;

            string text = input.ToLower();

            // Worried keywords
            if (text.Contains("worried") ||
                text.Contains("scared") ||
                text.Contains("afraid") ||
                text.Contains("anxious"))
            {
                return Sentiment.Worried;
            }

            // Curious keywords
            if (text.Contains("curious") ||
                text.Contains("interested") ||
                text.Contains("want to know") ||
                text.Contains("tell me"))
            {
                return Sentiment.Curious;
            }

            // Frustrated keywords
            if (text.Contains("frustrated") ||
                text.Contains("annoyed") ||
                text.Contains("angry") ||
                text.Contains("confused"))
            {
                return Sentiment.Frustrated;
            }

            return Sentiment.Neutral;
        }

        /// <summary>
        /// Produces a supportive opening sentence based on the detected sentiment.
        /// </summary>
        public string GetEmpathyOpening(Sentiment sentiment)
        {
            return sentiment switch
            {
                Sentiment.Worried => "It's completely understandable to feel worried. ",
                Sentiment.Curious => "That's a great question to be curious about! ",
                Sentiment.Frustrated => "I understand this can be frustrating. Let me help. ",
                _ => string.Empty
            };
        }
    }
}