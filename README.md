# 🚀 ManageDailyTasks — Desktop Task Manager Application

Welcome to **ManageDailyTasks**, a robust Windows Desktop application built using **C#** and **WinForms** on top of the **.NET Framework 4.8**. This project is a comprehensive Task Management system designed to guide users from a personalized onboarding experience to dynamically managing their daily routines, tracking priorities, and maintaining data persistence.

---

## 🔑 Key Features & Technical Architecture

### 1. User Onboarding & Personalization (`SetupForm`)
* **Custom Welcome Screen:** Users are greeted with an elegant, modern UI requesting their name. 
* **State Retention:** The entered name is stored globally to personalize the user experience in subsequent dashboards.
* **Navigation Control:** Includes standard interactive control buttons (`Next` and `Close`).

### 2. Comprehensive Task Management Dashboard (`TaskManagerForm`)
* **Dynamic Central Hub:** A unified interface displaying the current real-time digital clock (including hours, minutes, and seconds) alongside the user's name.
* **Structured Data Grid (`ListView`):** Displays all ongoing tasks cleanly mapped out under four dedicated metadata columns:
  * `Task Name`
  * `Task Type`
  * `Due Date / Timeline`
  * `Priority Level`

### 3. Smart Task Creator & Data Validation (`AddTaskForm`)
* **Input Enforcement (`ErrorProvider`):** Implements strict validation constraints. The application prevents focus-shifting or form submission if fields are left blank.
* **Custom Control Mapping:**
  * **Text Boxes:** For raw text inputs (Task Name).
  * **Combo Boxes:** Pre-seeded dropdown menus for categories, allowing customized user overrides.
  * **Radio Buttons:** Dynamic timeline switches (e.g., *Today*, *Later*).
* **Double-Check Verification:** Triggers a confirmation `MessageBox` highlighting the captured data schema before committing it to the interface.

### 4. Advanced UX & Feedback Systems
* **Dynamic Progress Bar:** A custom programmer-defined metric that automatically increments or decrements in real-time based on tasks added, deleted, or marked as completed.
* **Contextual Iconography:** Differentiates task urgencies graphically. Critical/High-priority items display a distinguished warning/priority icon, whereas generic tasks render a default task icon.
* **Double-Click Completion Workflow:** Users can double-click a row to prompt a completion dialog (`Yes`/`No`). Marking it `Yes` triggers a success message, safely disposes of the task, and smoothly calibrates the dynamic Progress Bar.
* **Defensive Deletion System:** Restricts users from firing an arbitrary deletion. A row must be explicitly highlighted; otherwise, an input error workflow triggers.

### 5. Storage & Persistence Layer (JSON Engine)
* **Flat-File JSON Storage:** As a bridge before utilizing heavy relational database engines (like SQL Server, MySQL, or SQLite), the app leverages **JSON Serialization/Deserialization** algorithms to safely parse runtime objects into physical local storage. This guarantees zero data loss upon application exit.

---

## 🛠️ Technology Stack
* **Language:** C#
* **Framework:** .NET Framework 4.8
* **UI Technology:** Windows Forms (WinForms)
* **Data Serialization:** Newtonsoft.Json / System.Text.Json
* **IDE:** Visual Studio 2019

---
## 📸 Media & Demos

### Application Interface
Here is a visual walkthrough of the application's interface layout and design:

| 🖼️ Onboarding & Welcome Screen | 🖼️ Main Task Management Center |
|:---:|:---:|
| <img src="https://c.top4top.io/p_3796yp93m1.jpg" width="450" alt="Welcome Screen"> | <img src="https://l.top4top.io/p_3796mvmde1.jpg" width="450" alt="Main Dashboard"> |

| 🖼️ Task Creation & Error Validation | 🖼️ Interactive Task Completion Dialog |
|:---:|:---:|
| <img src="https://c.top4top.io/p_3796mubx01.jpg" width="450" alt="Validation Form"> | <img src="https://i.top4top.io/p_3796rf6r81.jpg" width="450" alt="Completion Workflow"> |

---

### 🎥 Full Video Walkthrough
Watch a comprehensive, 8-minute architectural breakdown and live execution demo on Google Drive:
* 🎬 [Watch Project Demo Video](https://drive.google.com/file/d/1p_c9mu9wulO9KLdcwHmYJ3wkLiLiZl8m/view?usp=sharing)

*(Note: Please ensure your Google Drive share permissions are set to "Anyone with the link can view")*

---

## 📥 Download & Quick Start

To experience **ManageDailyTasks** on your machine, follow these simple steps:

1. **Visit the official page:** Go to [zuhairsh.itch.io/managedailytasks](https://zuhairsh.itch.io/managedailytasks).
2. **Download:** Click the **Download** button to get the compressed package.
3. **Extract:** Right-click the downloaded `.zip` file and select **"Extract All..."**.
4. **Run:** Open the extracted folder and double-click **`ManageDailyTasks.exe`** to launch the application.

> 💡 **Pro Tip:** If Windows SmartScreen appears, click **"More Info"** and then **"Run Anyway"**. This is a standard procedure for independent desktop applications.

---

### ⏱️ Development Insight
> **Development Time:** This project was constructed during an intensive, focused **8-hour sprint within a single day** (Shift 1: 1:00 PM – 5:00 PM | Shift 2: 12:00 AM – 5:00 AM). It stands as a baseline reflection of clean state management, modular WinForms workflow engineering, and robust algorithmic inputs.
