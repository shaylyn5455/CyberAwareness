using System;
using System.Windows;
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
namespace CyberAwareness_GUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // 1. Play the full audio from the Library first
            CyberAwareness.AppConfig.PlayGreeting();

            // 2. Then load the visual interface
            InitializeComponent();
        }

        // Keep your existing Button_Click or Chatbot logic below this line...
    }
}