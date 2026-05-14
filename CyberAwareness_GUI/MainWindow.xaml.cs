using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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
        private Chatbot sentinel = new Chatbot();
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        public MainWindow()
        {
            InitializeComponent();
            ChatDisplay.ItemsSource = Messages;

            // Start the system immediately since there's no login screen
            AppConfig.PlayGreeting();
            AddChatMessage("ARIES-X", "Access Granted. Connection Secure. Welcome back, Operator Shaylyn.");
            AddChatMessage("ARIES-X", "System is active. Type '1' for the Security Directory or say 'Hi'.");
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            ProcessInput();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ProcessInput();
        }

        private void ProcessInput()
        {
            string input = UserInput.Text;
            if (string.IsNullOrWhiteSpace(input)) return;

            // User message
            AddChatMessage("SHAYLYN", input.ToUpper());
            UserInput.Clear();

            // Bot response
            string response = sentinel.GetResponse(input);
            AddChatMessage("ARIES-X", response);

            // Auto-scroll to bottom
            ChatScroller.ScrollToBottom();
        }

        private void AddChatMessage(string sender, string message)
        {
            bool isBot = sender == "ARIES-X";
            Messages.Add(new ChatMessage
            {
                Message = $"{sender}: {message}",
                Alignment = isBot ? HorizontalAlignment.Left : HorizontalAlignment.Right,
                BubbleColor = isBot ? new SolidColorBrush(Color.FromRgb(30, 35, 50)) : new SolidColorBrush(Color.FromRgb(0, 60, 80))
            });
        }
    }

    public class ChatMessage
    {
        public string Message { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public SolidColorBrush BubbleColor { get; set; }
    }
}