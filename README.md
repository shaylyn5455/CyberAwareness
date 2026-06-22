# ARIES-X // Cyber Security Awareness Assistant Terminal

### 👤 Student Details
- **Operator Name:** Shaylyn Sookan
- **Student Number:** ST10295211
- **Module:** PROGRAMMING 2A (PROG6221/w) — Comprehensive POE Submission

---

## 🌌 Project Overview
Project Vision **ARIES-X** is a high-performance, visually striking WPF desktop terminal assistant built to provide critical cybersecurity education within the South African digital landscape. Designed with a sleek, tech-focused dark-mode aesthetic, the system offers an immersive, guided experience for operators to learn about data protection, threat prevention, and task tracking.

The application seamlessly unifies advanced conversational flow, audio feedback architectures, localized regular expression Natural Language Processing (NLP), and persistent external database integration into a singular, cohesive cybersecurity workspace.

---

## 🚀 Complete Feature Architecture

### 1. Interactive Conversational Engine (Core Topics)
The assistant is loaded with structured information trees to brief operators on critical security sectors:
- **POPIA Compliance:** Guidance on the Protection of Personal Information Act regulations within South Africa.
- **Phishing Countermeasures:** Identification matrix for malicious emails and fraudulent links.
- **Vishing & Social Engineering:** Defense mechanisms against voice-based banking scams and impersonation attacks.
- **Mobile Device Defense:** Security protocols for protecting smartphones from malicious network endpoints.

### 2. Audio Subsystem (Voice Greetings)
- Implements synchronized wave audio playback architectures (`System.Media.SoundPlayer`) to deliver real-time operational state notifications.
- Automatically executes an immediate voice greeting briefing upon terminal initialization to enhance operator immersion.

### 3. Dynamic Sentiment Detection & Tone Adaptation
- Evaluates incoming operator prompt matrices for emotional and behavioral indicators.
- Dynamically adapts the chatbot's response dialogue layout, vocabulary string selection, and visual design patterns to mirror or de-escalate user distress or urgency.

### 4. Task Assistant with Reminders & MySQL Storage (Task 1)
- **GUI Task Dashboard:** An organized interface allowing users to create, view, and clear critical security milestones (e.g., "Set up two-factor authentication").
- **Persistent MySQL Integration:** All security tasks are safely mirrored to a local database server instances using secure parameterised SQL queries to fully mitigate SQL Injection vulnerabilities.

### 5. Interactive Cybersecurity Mini-Game Quiz (Task 2)
- Features an evaluation engine pre-loaded with **11 mixed-format questions** (Multiple-Choice and True/False).
- Processes questions sequentially one at a time, providing immediate technical explanations and diagnostic logs for each answer.
- Tracks performance scoring variables and updates terminal metrics automatically upon completion.

### 6. NLP Simulation with Intent Routing (Task 3)
- Bypasses static, rigid keyword matching by utilizing advanced token regular expressions (`Regex.IsMatch`).
- Intelligently intercepts variable phrasing layouts (e.g., matching *"Can you remind me to check 2FA?"* or *"add task update password"*) and maps them natively to automated backend system events.

### 7. Telemetry Activity Logging System (Task 4)
- A dedicated background cache capturing operational records (system startups, database writes, user queries, and quiz completions).
- Displays up to **10 rolling localized sequences** upon specific command strings (such as *"Show activity log"* or *"What have you done for me?"*) to keep terminal telemetry concise and easy to navigate.

---

## 🛠️ Step-by-Step Local Workspace Setup Instructions

### 1. Requirements & Prerequisites
- Microsoft Visual Studio (with .NET Desktop Development workload enabled).
- MySQL Server instance running locally.
- MySQL Workbench.

### 2. Preparing the Database Schema
1. Launch **MySQL Workbench** and establish a local connection instance.
2. Open a new SQL Query tab, execute the following command to create the workspace container, and click Run:
   ```sql
   CREATE DATABASE cyberawareness_db;
