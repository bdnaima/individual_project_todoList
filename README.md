# 📝 ToDoLY - Console Task Manager

ToDoLY is a simple console-based task manager application built in C#.  
It allows users to create, manage, and track tasks with support for saving and loading data using JSON file storage.

---

## 📌 Features

- Add new tasks
- Edit existing tasks
- Mark tasks as done
- Remove tasks
- View all tasks
- Sort tasks by:
  - Date
  - Project
- Persistent storage using JSON file (tasks are saved and loaded automatically)
- Task status tracking (Done / NotDone)

---

## 🏗️ Project Structure

The project is split into three main parts:

- **Program.cs** → Handles user interface and menu system  
- **TaskManager.cs** → Contains all task logic (CRUD operations, sorting, file handling)  
- **TodoTask.cs** → Represents the task model (data structure)

---

## 💾 File Handling

Tasks are saved in a local JSON file called:


tasks.json


- When the program starts → tasks are loaded automatically  
- When the program exits → tasks are saved automatically  

This ensures no data is lost between sessions.

---

## 🧠 Concepts Used

- Object-Oriented Programming (OOP)
- Classes and Objects
- Enums
- Lists (Collections)
- File Handling
- JSON Serialization
- Basic CRUD operations

---

## 📂 Task Model

Each task contains:

- ID (unique identifier)
- Title
- Project (category)
- Due Date
- Status (Done / NotDone)

---

## ▶️ How to Run

1. Clone the repository
2. Open the project in Visual Studio or VS Code
3. Build and run the application
4. Use the console menu to manage tasks

---

## 📸 Example Usage


Welcome to ToDoLY

(1) Show tasks
(2) Add task
(3) Edit task
(4) Save and quit


---

## 🚀 Future Improvements

- Add search functionality
- Add priority levels
- Improve UI design
- Add deadlines reminders
- Add task categories filtering

---

## 👨‍💻 Naima Malik

Created as a learning project to practice C# and OOP principles.
