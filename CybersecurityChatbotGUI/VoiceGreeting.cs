using System;
using System.IO;
using System.Media;

namespace CybersecurityChatbotGUI
{
    /// <summary>
    /// Handles playback of the voice greeting WAV file.
    /// Plays the greeting in the BACKGROUND so the GUI opens immediately.
    /// </summary>
    public class VoiceGreeting
    {
        /// <summary>
        /// Plays the greeting.wav file in the background (non-blocking).
        /// Safe: if the file is missing the app will not crash.
        /// </summary>
        public void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Assets",
                    "greeting.wav"
                );

                if (File.Exists(audioPath))
                {
                    // Use Play() instead of PlaySync() so the GUI does not wait.
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.Play();
                    // Note: We do NOT use 'using' here because Play() runs in the background.
                    // The SoundPlayer will be garbage collected after playback completes.
                }
            }
            catch (Exception)
            {
                // Silently ignore audio errors.
            }
        }
    }
}
