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
namespace CyberAwareness
{
    public class Chatbot
    {
        /// <summary>
        /// Processes user input and returns a high-security ARIES response.
        /// </summary>
        /// <param name="input">The raw text from the user.</param>
        /// <returns>A formatted string response from the assistant.</returns>
        public string GetResponse(string? input)
        {
            // Null check and normalization to lowercase for keyword matching
            string query = input?.ToLower().Trim() ?? "";

            // Greeting Logic - Matches the friendly but professional tone
            if (query.Contains("hi") || query.Contains("hello") || query.Contains("hey"))
            {
                return "ARIES: Connection established. I am ready to assist with your security protocols.";
            }

            // MFA / Authentication Logic
            if (query.Contains("mfa") || query.Contains("factor"))
            {
                return "PROTOCOL MFA: Multi-Factor Authentication is active. It provides a critical second layer of defense beyond just a password.";
            }

            // VPN / Privacy Logic
            if (query.Contains("vpn") || query.Contains("private"))
            {
                return "PROTOCOL VPN: Secure tunnel verified. Using a VPN masks your IP address and encrypts data transmission.";
            }

            // Phishing / Threat Logic
            if (query.Contains("phishing") || query.Contains("scam"))
            {
                return "THREAT ALERT: Phishing detected in external sectors. Never click links or download attachments from unverified sources.";
            }

            // Firewall Logic
            if (query.Contains("firewall"))
            {
                return "SYSTEM DEFENSE: The firewall is your first line of network security, monitoring incoming and outgoing traffic.";
            }

            // TPM / Hardware Logic
            if (query.Contains("tpm"))
            {
                return "HARDWARE SEC: Trusted Platform Module (TPM) confirmed. Hardware-based encryption is protecting your sensitive data.";
            }

            // Default fallback response
            return "ARIES: Query not recognized in standard security database. I can assist with MFA, VPN, Phishing, or Firewall queries.";
        }
    }
}