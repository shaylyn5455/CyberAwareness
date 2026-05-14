using System;
using System.Media;
using System.IO;
/* S!--CODE ATTRIBUTION-->
<!--TITLE: Cyber awareness assistant - Program.cs-->
<--AUTHOR: (Adnan Yusra)->
SDATE: (13/05/2026)->
<--VERSION: (FIREST EDITION) --3
≤-AVAILABLE:
(https://advtechonline.sharepoint.com/:w:/r/sites/TertiaryStudents/_layouts/15/Doc.aspx?sour
/* * REFERENCE: Microsoft Learn (2024) - System.Media.SoundPlayer
 * URL: https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer
 * Purpose: Implements audio playback for Task 2.
 */
namespace CyberAwareness
{
    public static class AppConfig
    {
        public static void PlayGreeting()
        {
            try
            {
                // Locates the audio file in the execution folder
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AUDIOPROG.wav");

                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        // PlaySync is the fix: it stops the code from moving forward
                        // until the audio file has finished playing completely.
                        player.PlaySync();
                    }
                }
                else
                {
                    // Debug message in case the file isn't in the bin folder
                    Console.WriteLine("Audio file not found: " + audioPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio Error: " + ex.Message);
            }
        }
    }
}