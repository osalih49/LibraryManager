# 📚 Library Manager Console App

A simple C# console-based Library Management System that allows a user to manage books and library users. Built for learning purposes using Object-Oriented Programming (OOP) concepts.

## 🚀 Features

- 📘 Add / Remove Books
- 👤 Add Users (with auto-generated User IDs)
- 📚 Borrow & Return Books (max 3 per user)
- 📋 View Full Book Catalog (with total and available copies)
- 📊 Generate Reports showing:
  - All Books
  - Borrowed Books
  - Available Copies
  - All Users
  - Number of Books Currently Borrowed

## 🛠️ Technologies Used

- C#
- .NET Console Application

## 🧩 How It Works

When the program runs, you are presented with a menu:

Add Book

Remove Book

List Book

Add User

Borrow Book

Return Book

Generate Report

Exit

pgsql
Copy
Edit

Users can borrow up to 3 books at a time, and the system ensures only available books are borrowed. ISBNs and User IDs are auto-generated to avoid duplicates.

## 💡 Sample Output

Welcome to Book Manager System

Please choose from the options below:

Add Book

Remove Book
...

yaml
Copy
Edit

### 📦 Data Storage

Data is stored in memory during runtime using C# Lists, such as:

- `List<Book> _books`
- `List<User> _users`

---

## 🧑‍💻 Author

- Developed by Omar Salih
- Learning C# through hands-on OOP projects

---

