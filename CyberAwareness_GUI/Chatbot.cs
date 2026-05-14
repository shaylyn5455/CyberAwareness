namespace CyberAwareness_GUI
{
    public class Chatbot
    {
        public string GetResponse(string input)
        {
            string cleanInput = input.Trim().ToLower();

            // Numeric Menu Logic
            if (cleanInput == "1") return "ARIES: Security Scan Active. No threats detected.";
            if (cleanInput == "2") return "ARIES: [Coming Soon] Recent history is locked in this version.";
            if (cleanInput == "3") return "ARIES: Termination sequence initiated. Please close the app.";

            // Standard Keyword logic
            if (cleanInput.Contains("phishing")) return "ARIES: Phishing alert! Never click suspicious links.";
            if (cleanInput.Contains("firewall")) return "ARIES: Firewall is currently shielding your IP.";

            return "ARIES: Unknown Command. Type '1' for Scan, '2' for History, or '3' to Quit.";
        }
    }
}