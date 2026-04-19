# 📋 TaskPro — Employee Task Tracking & Reporting System

A full-featured **ASP.NET Core MVC** web application for managing, tracking, and reporting employee task progress within an organization.

---

## 🚀 Overview

**TaskPro** is an Employee Task Progress Management System built with ASP.NET Core MVC. It provides a centralized platform where managers can assign tasks to employees, monitor their progress, and generate reports — all through a clean and responsive web interface.

---

## ✨ Features

- 👤 **Employee Management** — Add, view, and manage employee records
- 📝 **Task Assignment** — Assign tasks to specific employees with deadlines
- 📊 **Progress Tracking** — Monitor real-time status of tasks (Pending, In Progress, Completed)
- 📈 **Reporting** — Generate progress reports for individuals or teams
- 🔒 **Role-Based Access** — Separate views and permissions for Admins and Employees
- 🎨 **Responsive UI** — Clean, Bootstrap-powered interface with Dark Mode support

---

## 🛠️ Tech Stack

| Layer        | Technology                          |
|--------------|-------------------------------------|
| Framework    | ASP.NET Core MVC                    |
| Language     | C#                                  |
| Frontend     | HTML, CSS, Bootstrap, Razor Views   |
| ORM          | Entity Framework Core (Code First)  |
| Architecture | MVC + ViewModel Pattern             |

---

## 📁 Project Structure

```
TaskPro/
├── Controllers/     # Request handling & business logic
├── Data/            # DbContext & EF Core configuration
├── Models/          # Domain models (Employee, Task, etc.)
├── ViewModel/       # ViewModels for Razor views
├── Views/           # Razor (.cshtml) UI pages
└── wwwroot/         # Static assets (CSS, JS, images)
```

---

## 📸 Screenshots

### 🔐 Login

<img width="1918" height="900" alt="1-login" src="https://github.com/user-attachments/assets/62b87c79-9d0c-470b-a0e5-d8793a219381" />

### 🏠 Dashboard


<img width="1337" height="640" alt="2-dashboard" src="https://github.com/user-attachments/assets/4fadcd80-35c4-4e69-892f-4e1ed78b2737" />

### 👥 Clients Directory
<img width="1363" height="638" alt="3-clients" src="https://github.com/user-attachments/assets/75f27922-e590-4e33-b149-655d5022b069" />

### 📁 Projects Directory

<img width="1354" height="607" alt="4-projects" src="https://github.com/user-attachments/assets/68e4a273-ae62-494e-8836-d6c0a7945c2e" />

### ✅ Tasks Directory

<img width="1346" height="613" alt="5-tasks" src="https://github.com/user-attachments/assets/8988c888-d0fe-4e7d-82bd-f0d8593e9573" />

### 📊 Work Reports

<img width="1343" height="623" alt="6-reports" src="https://github.com/user-attachments/assets/2134659b-ce5a-4743-94f2-9992bbde28f6" />

### 📅 Calendar View

<img width="1334" height="633" alt="7-calendar" src="https://github.com/user-attachments/assets/955f524e-694c-45f7-9487-12fe8036c06e" />

### 👤 Manage Users

<img width="1352" height="618" alt="8-users" src="https://github.com/user-attachments/assets/22f03f4a-8a44-41ef-9689-9751c7b20a06" />

### ⚙️ Settings

<img width="1348" height="629" alt="9-settings" src="https://github.com/user-attachments/assets/87e244dc-6701-4df2-bef0-6b66d9686b88" />

---

## ⚙️ Setup & Installation

### Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- SQL Server / LocalDB
- Visual Studio 2022 or VS Code

### Steps

```bash
# 1. Clone the repo
git clone https://github.com/RajaSaad555/EmployeeTaskProgress-TaskPro-.git
cd EmployeeTaskProgress-TaskPro-

# 2. Update connection string in appsettings.json
# "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskProDB;Trusted_Connection=True;"

# 3. Apply database migrations
dotnet ef database update

# 4. Run the app
dotnet run
```

Then open `https://localhost:5001` in your browser.

---

## 👨‍💻 Author

**Raja Saad**  
GitHub: [@RajaSaad555](https://github.com/RajaSaad555)

