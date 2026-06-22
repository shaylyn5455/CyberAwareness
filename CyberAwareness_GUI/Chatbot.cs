using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    public class Chatbot
    {
        private string lastTopic = "";
        private static List<string> activityLog = new List<string>();

        public static void LogAction(string description)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            activityLog.Add($"[{timestamp}] {description}");

            if (activityLog.Count > 10)
            {
                activityLog.RemoveAt(0);
            }
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "ARIES-X: Input channel empty. Please enter a valid security query or command.";
            }

            string clean = input.Trim().ToLower();
            string sentimentPrefix = DetectSentiment(clean);

            if (clean.Contains("show activity log") || clean.Contains("what have you done for me") || clean.Contains("view log"))
            {
                LogAction("User requested system activity log execution.");
                return DisplayActivityLog();
            }

            if (Regex.IsMatch(clean, @"\b(add|create|set|remind|save)\b.*\b(task|reminder|2fa|password|privacy|alert)\b"))
            {
                LogAction("NLP Parser interpreted intent: Add Security Task/Reminder.");
                return $"__ADD_TASK_INTENT__|{input}";
            }

            if (clean.Contains("quiz") || clean.Contains("play game") || clean.Contains("mini game") || clean.Contains("start test"))
            {
                LogAction("NLP Parser interpreted intent: Launch Cybersecurity Mini-Game Quiz.");
                return "__START_QUIZ_INTENT__";
            }

            if (clean.Contains("hello") || clean.Contains("hi") || clean.Contains("hey") || clean.Contains("good day"))
            {
                LogAction("User initiated session greeting.");
                return "ARIES-X: Hello, Operator Shaylyn. Connection is secure. How can I assist you with your digital defense today?";
            }

            if (clean.Contains("what can i ask") || clean.Contains("options") || clean.Contains("help"))
            {
                LogAction("User requested available documentation and command options.");
                return "ARIES-X: You can ask me about these security sectors: \n• POPIA (Privacy Laws) \n• Banking Scams \n• Mobile Safety \n• Email Phishing \n\nAlternatively, you can manage your database schedule by asking to \"add a task\" or challenge yourself by asking to \"start the quiz\".\n\nWhich protocol shall we analyze?";
            }

            if (clean == "yes" || clean == "yup" || clean == "ok" || clean == "sure")
            {
                LogAction("User confirmed sequence continuation step.");
                if (lastTopic == "popia") return GetResponse("banking");
                if (lastTopic == "banking") return GetResponse("mobile");
                if (lastTopic == "mobile") return GetResponse("phishing");
                return "ARIES-X: Confirmation registered. I'm ready. Please choose a topic or type '1' for the main directory.";
            }

            if (clean == "no" || clean == "nope")
            {
                LogAction("User declined sequence continuation step.");
                lastTopic = "";
                return "ARIES-X: Understood. Action cancelled. I'll remain on standby. Type '1' to see the options again whenever you're ready.";
            }

            if (clean == "1" || clean == "directory" || clean.Contains("menu"))
            {
                LogAction("User pulled up the primary directory navigation menu.");
                lastTopic = "menu";
                return "ARIES-X: DIRECTORY ACTIVE: \n• POPIA \n• Banking Scams \n• Mobile Safety \n• Phishing \n\nWhich protocol shall we analyze?";
            }

            if (clean.Contains("popia") || clean.Contains("privacy"))
            {
                LogAction("Database query accessed: POPIA Sector.");
                lastTopic = "popia";
                return sentimentPrefix + "POPIA ensures your personal data in SA stays private. It stops businesses from using your info without a legal reason. \n\nWould you like to move on to 'Banking Scams' next? (Yes/No)";
            }

            if (clean.Contains("banking") || clean.Contains("scam") || clean.Contains("vishing"))
            {
                LogAction("Database query accessed: Financial Vishing Sector.");
                lastTopic = "banking";
                return sentimentPrefix + "Vishing (voice phishing) is used to steal bank OTPs. Note: Your bank will never call to ask for your pin. \n\nShould we discuss 'Mobile Safety' next? (Yes/No)";
            }

            if (clean.Contains("mobile") || clean.Contains("phone"))
            {
                LogAction("Database query accessed: Mobile Device Endpoint Defense.");
                lastTopic = "mobile";
                return sentimentPrefix + "Mobile safety includes 'Remote Wipe' and biometric locks to protect your phone if stolen. \n\nWould you like to learn about 'Phishing' next? (Yes/No)";
            }

            if (clean.Contains("phishing") || clean.Contains("email"))
            {
                LogAction("Database query accessed: Phishing Attack Paradigms.");
                lastTopic = "phishing";
                return sentimentPrefix + "Phishing uses fake emails to steal passwords. Always check the sender's actual email address. \n\nDo you want to return to the Menu? (Yes/No)";
            }

            LogAction($"Unrecognized command signature processed: \"{input}\"");
            return "ARIES-X: Command unrecognized by current NLP string patterns. You can ask 'What can I ask you about?', say 'add a task', 'start the quiz', or type '1' for the main directory.";
        }

        private string DetectSentiment(string input)
        {
            if (Regex.IsMatch(input, @"\b(scared|hacked|stolen|leak|compromised|dangerous|wrong|bad|error|help|fail|dont understand)\b"))
            {
                return "[Tone Analysis: Defensive Alert Status] System detects potential breach anxiety. Initializing soothing protocols...\nARIES-X: ";
            }
            if (Regex.IsMatch(input, @"\b(great|awesome|cool|thanks|thank you|good|perfect|smart|happy|win|correct)\b"))
            {
                return "[Tone Analysis: Operational Optimization] Positive telemetry acknowledged. System efficiency nominal.\nARIES-X: ";
            }
            return "";
        }

        private string DisplayActivityLog()
        {
            if (activityLog.Count == 0)
            {
                return "ARIES-X: Operational log register is currently empty. Perform actions within the environment to generate telemetry tracking.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ARIES-X: SECURE ACTIVITY LOG DATA EXCHANGE:");
            sb.AppendLine("--------------------------------------------------");
            foreach (var logEntry in activityLog)
            {
                sb.AppendLine(logEntry);
            }
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine($"Showing last {activityLog.Count} actions. End of secure packet transmission.");
            return sb.ToString();
        }
    }
}