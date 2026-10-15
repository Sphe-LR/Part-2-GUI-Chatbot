using System;

namespace CybersecurityChatbotGUI
{
    /// <summary>
    /// Stores information the chatbot remembers about the user.
    /// Supports memory & recall (Part 2 requirement).
    /// </summary>
    public class MemoryStore
    {
        /// <summary>The user's name, remembered across the session.</summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>The topic the user is currently discussing.</summary>
        public string CurrentTopic { get; set; } = string.Empty;

        /// <summary>The user's favourite cybersecurity topic, if stated.</summary>
        public string FavouriteTopic { get; set; } = string.Empty;

        /// <summary>Returns true if the chatbot has a name stored.</summary>
        public bool HasUserName()
        {
            return !string.IsNullOrWhiteSpace(UserName);
        }

        /// <summary>Returns true if the chatbot has a favourite topic stored.</summary>
        public bool HasFavouriteTopic()
        {
            return !string.IsNullOrWhiteSpace(FavouriteTopic);
        }

        /// <summary>Resets all stored memory values.</summary>
        public void Clear()
        {
            UserName = string.Empty;
            CurrentTopic = string.Empty;
            FavouriteTopic = string.Empty;
        }
    }
}