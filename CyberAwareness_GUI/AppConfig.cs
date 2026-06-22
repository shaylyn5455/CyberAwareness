using System;
using System.Media;
using System.IO;
/* S!--CODE ATTRIBUTION-->
<!--TITLE: Cyber awareness assistant - Program.cs-->
<--AUTHOR: (Adnan Yusra)->
SDATE: (22/06/2026)->
<--VERSION: (FIREST EDITION) --3
≤-AVAILABLE:
(https://advtechonline.sharepoint.com/:w:/r/sites/TertiaryStudents/_layouts/15/Doc.aspx?sour
/* * REFERENCE: Microsoft Learn (2024) - System.Media.SoundPlayer
 * URL: https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer
 * Purpose: Implements audio playback for Task 2.
 */
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