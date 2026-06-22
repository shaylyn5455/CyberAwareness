# ARIES-X // Cybersecurity Awareness Assistant Terminal

An advanced WPF desktop application designed to educate operators on key cybersecurity principles (POPIA compliance, Phishing patterns, Banking Scams, and Mobile Safety) using an interactive AI conversational shell interface.

## 🚀 Features & Integration Architecture
- **Task Assistant with Reminders (Task 1):** Fully integrated GUI interface managing database pipelines to record and monitor security configuration milestones.
- **MySQL Database Storage (Task 1):** Robust connection handling using automated table construction and safe parameterised SQL queries to fully prevent injection vulnerabilities.
- **Cybersecurity Mini-Game Quiz (Task 2):** A built-in 11-question evaluation examination featuring randomized multiple-choice and true/false inquiries with immediate educational explanation diagnostics.
- **Natural Language Processing Simulation (Task 3):** Dynamic phrasing intent routing engine matching contextual query strings using flexible regular expressions (`Regex`).
- **Telemetry Activity Log (Task 4):** A running operational action cache displaying up to 10 localized sequence metrics upon request.

## 🛠️ Step-by-Step Local Workspace Setup Instructions

### 1. Requirements & Prerequisites
- Microsoft Visual Studio (with .NET Desktop Development workload enabled).
- MySQL Server & MySQL Workbench installed locally.

### 2. Preparing the Database Schema Setup
1. Launch **MySQL Workbench** and establish a local root connection instance.
2. Open a new SQL Query tab and run the following command to create the workspace container:
   ```sql
   CREATE DATABASE cyberawareness_db;
