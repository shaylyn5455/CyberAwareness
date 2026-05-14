using System;
using System.Windows;

namespace CyberAwareness_GUI
{
    public partial class MainWindow : Window
    {
        private Chatbot aries = new Chatbot();
        private int messagesSent = 0;
        private const int MAX_MESSAGES = 5;

        public MainWindow()
        {
            AppConfig.PlayGreeting();
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            // Requirement: Users must be authenticated before sending messages
            if (PassInput.Password.ToLower() == "admin")
            {
                LoginOverlay.Visibility = Visibility.Collapsed;
                StatusText.Text = "SYSTEM: Authenticated. Session Active.";
                ChatHistory.Items.Add("ARIES: Welcome to QuickChat. Type '1' for Menu.");
            }
            else
            {
                MessageBox.Show("ACCESS DENIED.");
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (messagesSent < MAX_MESSAGES)
            {
                string input = UserInput.Text;
                if (!string.IsNullOrEmpty(input))
                {
                    ChatHistory.Items.Add("USER: " + input);

                    // Requirement: Loop and String Manipulation
                    string response = aries.GetResponse(input);
                    ChatHistory.Items.Add(response);

                    messagesSent++;
                    StatusText.Text = $"MESSAGES: {messagesSent}/{MAX_MESSAGES}";
                    UserInput.Clear();
                    ChatHistory.ScrollIntoView(ChatHistory.Items[ChatHistory.Items.Count - 1]);
                }
            }
            else
            {
                MessageBox.Show("Message limit reached for this session.");
            }
        }
    }
}