using System;
using System.Media;
using System.IO;

namespace CyberAwareness_GUI
{
    public static class AppConfig
    {
        public static void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AUDIOPROG.wav");

                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.PlaySync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Audio Error: " + ex.Message);
            }
        }
    }
}