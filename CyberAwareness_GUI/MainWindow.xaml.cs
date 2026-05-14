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
        private Chatbot aries = new Chatbot();
        private int messagesSent = 0;
        private const int MAX_MESSAGES = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassInput.Password.ToLower() == "admin")
            {
                LoginOverlay.Visibility = Visibility.Collapsed;
                AddChatMessage("ARIES-X: Access Granted. Welcome, Operator Shaylyn.", false);
            }
            else
            {
                MessageBox.Show("Access Denied.");
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (messagesSent < MAX_MESSAGES)
            {
                string input = UserInput.Text;
                if (!string.IsNullOrEmpty(input))
                {
                    AddChatMessage("SHAYLYN: " + input, true);
                    string response = aries.GetResponse(input);
                    AddChatMessage(response, false);

                    messagesSent++;
                    UserInput.Clear();
                }
            }
            else
            {
                AddChatMessage("SYSTEM: Message limit reached. Terminal session locked.", false);
            }
        }

        // COPY AND PASTE THIS PART OVER YOUR OLD HELPER
        private void AddChatMessage(string text, bool fromUser)
        {
            // Create the message object
            var newMessage = new { Message = text, IsUser = fromUser };

            // Add it to the list
            ChatHistory.Items.Add(newMessage);

            // AUTO-SCROLL: This makes it jump to the bottom like the video
            ChatHistory.ScrollIntoView(newMessage);
        }
    }
}