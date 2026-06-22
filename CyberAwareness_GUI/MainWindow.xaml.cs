using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;
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
    public partial class MainWindow : Window
    {
        private Chatbot sentinel = new Chatbot();
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        // --- DATABASE CONFIGURATION (Task 1) ---
        private readonly string dbConnectionString = "Server=localhost;Database=cyberawareness_db;Uid=root;Pwd=password;";

        // --- QUIZ STATE ENGINE FIELDS (Task 2) ---
        private bool isQuizActive = false;
        private int currentQuestionIndex = 0;
        private int userScore = 0;
        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();

        public MainWindow()
        {
            InitializeComponent();
            ChatDisplay.ItemsSource = Messages;

            // Start the system immediately since there's no login screen
            AppConfig.PlayGreeting();
            InitializeDatabase();
            InitializeQuizQuestions();

            Chatbot.LogAction("System Core initialized successfully.");
            AddChatMessage("ARIES-X", "Access Granted. Connection Secure. Welcome back, Operator Shaylyn.");
            AddChatMessage("ARIES-X", "System is active. Type '1' for the Security Directory, type 'quiz' to test your skills, or type 'add task' to log security requirements.");
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

            // Display raw User message on terminal screen
            AddChatMessage("SHAYLYN", input.ToUpper());
            UserInput.Clear();

            // --- ROUTING MODE A: IN-GAME ACTIVE QUIZ PROCESSING ---
            if (isQuizActive)
            {
                // Video Intercept: Gracefully break quiz states
                string exitCheck = input.Trim().ToLower();
                if (exitCheck == "exit" || exitCheck == "quit" || exitCheck == "stop")
                {
                    isQuizActive = false;
                    Chatbot.LogAction("User manually terminated active quiz sequence.");
                    AddChatMessage("ARIES-X", "⚠️ TERMINATION SEQUENCE ACTIVATED: Quiz evaluation cancelled. Returning to Core Interface...");
                    AddChatMessage("ARIES-X", "System is active. Type '1' for the Security Directory.");
                    ChatScroller.ScrollToBottom();
                    return;
                }

                HandleQuizAnswer(input.Trim());
                ChatScroller.ScrollToBottom();
                return;
            }

            // --- ROUTING MODE B: REVERSE UTILITY INTERCEPT FOR QUICK DATABASE MANIPULATION ---
            string lowerInput = input.Trim().ToLower();
            if (lowerInput.StartsWith("delete task "))
            {
                string rawId = lowerInput.Replace("delete task ", "").Trim();
                if (int.TryParse(rawId, out int taskId))
                {
                    DeleteTaskFromDatabase(taskId);
                }
                else
                {
                    AddChatMessage("ARIES-X", "ERROR: Invalid numeric task ID structural argument supplied.");
                }
                ChatScroller.ScrollToBottom();
                return;
            }
            if (lowerInput == "view tasks" || lowerInput == "list tasks" || lowerInput == "show tasks")
            {
                DisplayStoredTasks();
                ChatScroller.ScrollToBottom();
                return;
            }

            // --- ROUTING MODE C: CONVERSATIONAL ENGINE & NLP INTERCEPT ROUTING ---
            string response = sentinel.GetResponse(input);

            if (response.StartsWith("__ADD_TASK_INTENT__"))
            {
                AddChatMessage("ARIES-X", "NLP PARSER: Intent recognized -> [Database Task Generation]. Initializing remote schema record creation sequence...");
                ParseAndAddTaskFromNlp(input);
            }
            else if (response == "__START_QUIZ_INTENT__")
            {
                StartQuizSequence();
            }
            else
            {
                AddChatMessage("ARIES-X", response);
            }

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

        // ==========================================
        // TASK 1: DATABASE INTEGRATION & UTILITIES
        // ==========================================
        private void InitializeDatabase()
        {
            try
            {
                using (var conn = new MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS cybersecurity_tasks (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            title VARCHAR(100) NOT NULL,
                            description TEXT NOT NULL,
                            reminder_days INT DEFAULT 0,
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                        );";
                    using (var cmd = new MySqlCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    Chatbot.LogAction("MySQL remote database connection verified. Security schema synchronised.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Database Connection Error: " + ex.Message);
                Chatbot.LogAction($"Database connectivity operational fault flag: {ex.Message}");
            }
        }

        private void ParseAndAddTaskFromNlp(string rawInput)
        {
            string title = "Verify Endpoint Access Parameters";
            string description = "Review overall configuration for system entry vectors.";
            int reminderDays = 7;

            if (Regex.IsMatch(rawInput.ToLower(), @"\b(2fa|two factor|two-factor)\b"))
            {
                title = "Configure Multi-Factor Verification Controls";
                description = "Deploy multi-factor software key checkpoints for peripheral systems.";
                reminderDays = 1;
            }
            else if (Regex.IsMatch(rawInput.ToLower(), @"\b(password|passwords)\b"))
            {
                title = "Rotate Core Access Security Credentials";
                description = "Audit cryptographic string entropy values on user storage clusters.";
                reminderDays = 3;
            }
            else if (Regex.IsMatch(rawInput.ToLower(), @"\b(privacy|popia)\b"))
            {
                title = "Execute POPIA Content Compliance Scan";
                description = "Scrub target database assets for unencrypted personally identifiable entries.";
                reminderDays = 14;
            }

            try
            {
                using (var conn = new MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO cybersecurity_tasks (title, description, reminder_days) VALUES (@title, @desc, @remind);";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@desc", description);
                        cmd.Parameters.AddWithValue("@remind", reminderDays);
                        cmd.ExecuteNonQuery();
                    }
                }

                Chatbot.LogAction($"Database Task added: '{title}'");
                AddChatMessage("ARIES-X", $"SUCCESSFULLY LOGGED SECURITY REQUIREMENT IN DATABASE:\n• Title: {title}\n• Description: {description}\n• Timeframe Alert: Set for {reminderDays} day(s).\n\nType 'view tasks' to display the current pipeline status matrix.");
            }
            catch (Exception ex)
            {
                AddChatMessage("ARIES-X", $"CRITICAL SCHEDULING IO FAILURE: Could not write record. Details: {ex.Message}");
            }
        }

        private void DisplayStoredTasks()
        {
            try
            {
                using (var conn = new MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    string selectQuery = "SELECT id, title, description, reminder_days FROM cybersecurity_tasks ORDER BY id DESC;";
                    using (var cmd = new MySqlCommand(selectQuery, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            AddChatMessage("ARIES-X", "DATABASE METRICS: Pipeline registers empty. No pending cybersecurity tasks scheduled.");
                            return;
                        }

                        string taskListOutput = "ACTIVE PIPELINE REQUISITION LOGS:\n================================";
                        while (reader.Read())
                        {
                            taskListOutput += $"\nID [{reader["id"]}]: {reader["title"]}\n   Details: {reader["description"]}\n   Reminder: Alert active for {reader["reminder_days"]} days from creation.\n--------------------------------";
                        }
                        taskListOutput += "\n\nTo clean completed nodes, enter the following signature: 'delete task [ID]'";
                        AddChatMessage("ARIES-X", taskListOutput);
                    }
                }
                Chatbot.LogAction("User read current task pipeline metrics out of the system database.");
            }
            catch (Exception ex)
            {
                AddChatMessage("ARIES-X", $"CRITICAL PIPELINE ACCESS ERROR: {ex.Message}");
            }
        }

        private void DeleteTaskFromDatabase(int id)
        {
            try
            {
                int rowsAffected = 0;
                using (var conn = new MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM cybersecurity_tasks WHERE id = @id;";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                if (rowsAffected > 0)
                {
                    AddChatMessage("ARIES-X", $"SUCCESS: Schema record ID [{id}] wiped out of production indexes.");
                    Chatbot.LogAction($"Database Task node removed. ID: {id}");
                }
                else
                {
                    AddChatMessage("ARIES-X", $"OPERATION VOIDED: Task ID [{id}] could not be traced inside our production indexes.");
                }
            }
            catch (Exception ex)
            {
                AddChatMessage("ARIES-X", $"CRITICAL CRUD PARSING ERROR: {ex.Message}");
            }
        }

        // ==========================================
        // TASK 2: MINI-GAME SYSTEM (QUIZ LOGIC)
        // ==========================================
        private void InitializeQuizQuestions()
        {
            quizQuestions.Clear();
            quizQuestions.Add(new QuizQuestion("What should you do if you receive an unexpected email containing urgent verification hyperlinks?\nA) Reply immediately with parameters\nB) Delete the transmission package\nC) Report the email as phishing\nD) Follow instructions to remove holds", "C", "Phishing simulations highlight reporting suspect items immediately to minimize spread windows."));
            quizQuestions.Add(new QuizQuestion("Is utilizing identical access codes across separate nodes safe if they feature high complexity? (True/False)", "FALSE", "Credential recycling enables threat actors to execute full systemic cascading account access takeovers."));
            quizQuestions.Add(new QuizQuestion("What layer of security verification adds a physical validation prompt token to generic entry operations?\nA) Symmetric Encryption\nB) Multi-Factor Authentication (MFA)\nC) Biometric Scanning\nD) Reverse Proxy Handshaking", "B", "MFA enforces confirmation across isolated networks to verify user validity."));
            quizQuestions.Add(new QuizQuestion("Social engineering attacks focus solely on breaching network ports through algorithmic brute force. (True/False)", "FALSE", "Social engineering manipulates human psychology to trick users into handing over secure authorization strings willingly."));
            quizQuestions.Add(new QuizQuestion("Which option defines safe behavior when interfacing with public wireless hotspot zones?\nA) Accessing corporate financial ledgers\nB) Deactivating firewall protection blocks\nC) Routing traffic profiles via a secure VPN channel\nD) Permitting general directory folder sharing", "C", "Virtual Private Networks tunnel connection packets within end-to-end encrypted paths over public hotspots."));
            quizQuestions.Add(new QuizQuestion("Phishing techniques are exclusive to standard desktop email clients. (True/False)", "FALSE", "Phishing scams target SMS (Smishing), instant messages, phone calls (Vishing), and social platform channels."));
            quizQuestions.Add(new QuizQuestion("What structural concept describes an unauthorized software component locking enterprise records for extortion payoffs?\nA) Polymorphic Trojan\nB) Ransomware Suite\nC) Adware Injection Spy\nD) Rootkit Core Overwrite", "B", "Ransomware holds critical data structures hostage using complex mathematical encryption keys."));
            quizQuestions.Add(new QuizQuestion("A strong complex password character combination is perfectly safe if taped to your display monitor frame. (True/False)", "FALSE", "Physical credential exposures present unmanaged surface attack risks that bypass virtual firewall controls."));
            quizQuestions.Add(new QuizQuestion("What is the main objective of the local POPIA legislative mandate rules?\nA) Enforcing fast download speed limits\nB) Protecting personal tracking records from unmanaged corporate exploitation\nC) Taxing cross-border hardware storage systems\nD) Filtering access permissions on the dark web", "B", "POPIA protects individual data privacy and penalizes unconsented data processing."));
            quizQuestions.Add(new QuizQuestion("Antivirus detection definition files should remain unchanged for months to maintain system benchmarking rates. (True/False)", "FALSE", "Definition indices must update constantly to keep pace with new zero-day vulnerability exploits."));
            quizQuestions.Add(new QuizQuestion("What feature allows remote wipe commands to protect device data stores in case of physical theft?\nA) Remote Wipe\nB) Background Fragment Defragmentation\nC) Cloud Backup Synch Only\nD) Dynamic Display Screen Rotation", "A", "Remote wiping purges files on an endpoint device over network connections if physical custody is lost."));
        }

        private void StartQuizSequence()
        {
            isQuizActive = true;
            currentQuestionIndex = 0;
            userScore = 0;
            AddChatMessage("ARIES-X", "==================================================\nINITIALIZING CYBERSECURITY SKILLS EXAMINATION PANEL\n==================================================\nRespond to each inquiry directly by selecting the corresponding string indicator choice (e.g., A, B, C, D, or True/False).\nType 'EXIT' at any point to stop.");
            PresentQuizQuestion();
        }

        private void PresentQuizQuestion()
        {
            if (currentQuestionIndex < quizQuestions.Count)
            {
                var questionObj = quizQuestions[currentQuestionIndex];
                AddChatMessage("ARIES-X", $"QUESTION [{currentQuestionIndex + 1}/{quizQuestions.Count}]:\n{questionObj.QuestionText}");
            }
        }

        private void HandleQuizAnswer(string answer)
        {
            var currentQuestion = quizQuestions[currentQuestionIndex];
            bool isCorrect = answer.Equals(currentQuestion.CorrectAnswer, StringComparison.OrdinalIgnoreCase);

            if (isCorrect)
            {
                userScore++;
                AddChatMessage("ARIES-X", $"CORRECT: Progress verified. Feedback: {currentQuestion.Explanation}");
            }
            else
            {
                AddChatMessage("ARIES-X", $"ALERT: Incorrect parameters. Expected choice signature: '{currentQuestion.CorrectAnswer}'.\nFeedback: {currentQuestion.Explanation}");
            }

            currentQuestionIndex++;

            if (currentQuestionIndex < quizQuestions.Count)
            {
                PresentQuizQuestion();
            }
            else
            {
                isQuizActive = false;
                string performanceSummary = $"EXAMINATION COMPLETED. Score Registered: {userScore}/{quizQuestions.Count}.\n";

                if (userScore >= 9) performanceSummary += "RANK STATUS: Great job! You're a cybersecurity pro!";
                else if (userScore >= 5) performanceSummary += "RANK STATUS: Operational parameters average. Keep learning to stay safe online!";
                else performanceSummary += "RANK STATUS: Breach Risk High. Immediate documentation overview recommended.";

                AddChatMessage("ARIES-X", performanceSummary);
                Chatbot.LogAction($"Cybersecurity Quiz Module completed. User achieved score profile of {userScore}/{quizQuestions.Count}");
            }
        }
    }

    public class ChatMessage
    {
        public string Message { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public SolidColorBrush BubbleColor { get; set; }
    }

    public class QuizQuestion
    {
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string text, string answer, string expl)
        {
            QuestionText = text;
            CorrectAnswer = answer;
            Explanation = expl;
        }
    }
}