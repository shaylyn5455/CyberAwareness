using System;
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
    public class Chatbot
    {
        private string lastTopic = "";

        public string GetResponse(string input)
        {
            string clean = input.Trim().ToLower();

            // --- 1. GREETINGS (The "Greet Back" Logic) ---
            if (clean.Contains("hello") || clean.Contains("hi") || clean.Contains("hey") || clean.Contains("good day"))
            {
                return "ARIES-X: Hello, Operator Shaylyn. Connection is secure. How can I assist you with your digital defense today?";
            }

            // --- 2. META-QUESTIONS (The "What can I ask?" Logic) ---
            if (clean.Contains("what can i ask") || clean.Contains("options") || clean.Contains("help"))
            {
                return "ARIES-X: You can ask me about these security sectors: \n• POPIA (Privacy Laws) \n• Banking Scams \n• Mobile Safety \n• Email Phishing \n\nWhich one would you like to investigate?";
            }

            // --- 3. HANDLING "YES" ---
            if (clean == "yes" || clean == "yup" || clean == "ok" || clean == "sure")
            {
                if (lastTopic == "popia") return GetResponse("banking");
                if (lastTopic == "banking") return GetResponse("mobile");
                if (lastTopic == "mobile") return GetResponse("phishing");
                return "ARIES-X: I'm ready. Please choose a topic or type '1' for the main directory.";
            }

            // --- 4. HANDLING "NO" ---
            if (clean == "no" || clean == "nope")
            {
                lastTopic = "";
                return "ARIES-X: Understood. I'll remain on standby. Type '1' to see the options again whenever you're ready.";
            }

            // --- 5. MAIN TOPICS (The "Options") ---
            if (clean == "1" || clean.Contains("menu"))
            {
                lastTopic = "menu";
                return "ARIES-X: DIRECTORY ACTIVE: \n• POPIA \n• Banking Scams \n• Mobile Safety \n• Phishing \n\nWhich protocol shall we analyze?";
            }

            if (clean.Contains("popia") || clean.Contains("privacy"))
            {
                lastTopic = "popia";
                return "ARIES-X: POPIA ensures your personal data in SA stays private. It stops businesses from using your info without a legal reason. \n\nWould you like to move on to 'Banking Scams' next? (Yes/No)";
            }

            if (clean.Contains("banking") || clean.Contains("scam") || clean.Contains("vishing"))
            {
                lastTopic = "banking";
                return "ARIES-X: Vishing (voice phishing) is used to steal bank OTPs. Note: Your bank will never call to ask for your pin. \n\nShould we discuss 'Mobile Safety' next? (Yes/No)";
            }

            if (clean.Contains("mobile") || clean.Contains("phone"))
            {
                lastTopic = "mobile";
                return "ARIES-X: Mobile safety includes 'Remote Wipe' and biometric locks to protect your phone if stolen. \n\nWould you like to learn about 'Phishing' next? (Yes/No)";
            }

            if (clean.Contains("phishing") || clean.Contains("email"))
            {
                lastTopic = "phishing";
                return "ARIES-X: Phishing uses fake emails to steal passwords. Always check the sender's actual email address. \n\nDo you want to return to the Menu? (Yes/No)";
            }

            // --- FALLBACK ---
            return "ARIES-X: Command unrecognized. You can ask 'What can I ask you about?' or type '1' for the directory.";
        }
    }
}