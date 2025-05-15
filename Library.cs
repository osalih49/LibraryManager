using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Library
    {
        private List<Book> _books = new List<Book>();
        private List<User> _users = new List<User>();

        public Library()
        {
            _books = new List<Book>();
            _users = new List<User>();
        }

        public void AddBook()
        {
            Console.WriteLine("Enter Book Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Author Name: ");
            string author = Console.ReadLine();

            Console.WriteLine("Enter total number of copies: ");
            if (!int.TryParse(Console.ReadLine(), out int totalCopies) || totalCopies <= 0)
            {
                Console.WriteLine("Invalid number of copies.");
                return;
            }

            Random random = new Random();
            string isbn = "";

            for (int i = 0; i < 13; i++)
            {
                isbn += random.Next(0, 9);
            } while (_books.Any(book => book.ISBN == isbn));

            Book newBook = new Book(title, author, isbn, totalCopies);
            _books.Add(newBook);
            Console.WriteLine($"\n✅ Book '{title}' added successfully!");
            Console.WriteLine($"Auto-assigned ISBN: {isbn}");
        }


        public void RemoveBook()
        {
           if(_books.Count == 0)
            {
                Console.WriteLine("There are no Books currently available to remove");
                return;
            }

            Console.WriteLine("\nAvailable Books: ");
            foreach (Book book in _books)
            {
                Console.WriteLine($"- {book.Title} (ISBN: {book.ISBN})");
            }
            Console.Write("\nEnter ISBN of the book you want to remove: ");
            string isbnToRemove = Console.ReadLine();

            Book bookToRemove = _books.FirstOrDefault(b => b.ISBN == isbnToRemove);

            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
                Console.WriteLine($"\n Book '{bookToRemove.Title}' removed successfully!");
            }
            else
            {
                Console.WriteLine("\n Book not found. Please check the ISBN and try again.");
            }
        }


        public void ListBooks()
        {
            Console.WriteLine("\n Current Library Catalog");

            if (_books.Count == 0)
            {
                Console.WriteLine(" No books found.\n");
                return;
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("{0,-30} | {1,-20} | {2,-15} | {3,8} | {4,8}",
                              "Title", "Author", "ISBN", "Total", "Available");
            Console.WriteLine(new string('-', 100));

            foreach (Book book in _books)
            {
                Console.WriteLine("{0,-30} | {1,-20} | {2,-15} | {3,8} | {4,8}",
                                  book.Title, book.Author, book.ISBN,
                                  book.TotalCopies, book.AvailableCopies);
            }

            Console.WriteLine(new string('-', 100));
        }


        public void AddUser()
        {
            Console.WriteLine("Create User below");
            Console.WriteLine("First Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string lname = Console.ReadLine();
           
            Random random = new Random();
            string userID = "";

            for (int i = 0; i < 5; i++)
            {
                userID += random.Next(0, 9);
            } while (_users.Any(user => user.UserID == userID));

            List<Book> borrowedBooks = new List<Book>();

            User newUser = new User(fname, lname, userID, borrowedBooks);
            _users.Add(newUser);
            Console.WriteLine($"\n  '{fname} {lname}' added successfully!");
            Console.WriteLine($"Auto-assigned userID: {userID}");
        }

        public void BorrowBook()
        {
            Console.WriteLine("Enter your User ID: ");
            string userID = Console.ReadLine();

            var user = _users.FirstOrDefault(u => u.UserID == userID);
            if (user == null)
            {
                Console.WriteLine(" User Not Found");
                return;
            }

          
            if (user.BorrowedBooks.Count > 0)
            {
                Console.WriteLine("\n You Already Borrowed:");
                foreach (var book in user.BorrowedBooks)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }
            }

            if (user.BorrowedBooks.Count >= 3)
            {
                Console.WriteLine(" You have reached the borrowing limit (3 books).");
                return;
            }

      
            var availableBooks = _books.Where(b => b.AvailableCopies > 0).ToList();

            if (availableBooks.Count == 0)
            {
                Console.WriteLine(" No books available to borrow.");
                return;
            }

            Console.WriteLine("\n Available Books:");
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN}) - {book.AvailableCopies} copies left");
            }

         
            Console.Write("\nEnter the ISBN of the book to borrow: ");
            string isbn = Console.ReadLine();

            var selectedBook = _books.FirstOrDefault(b => b.ISBN == isbn);
            if (selectedBook == null || selectedBook.AvailableCopies <= 0)
            {
                Console.WriteLine(" Book not found or unavailable.");
                return;
            }

            selectedBook.AvailableCopies--;
            user.BorrowedBooks.Add(selectedBook);

            Console.WriteLine($"\n✅ '{selectedBook.Title}' successfully borrowed.");
        }


        public void ReturnBook()
        {
            Console.WriteLine("Enter User ID");
            string userID = Console.ReadLine();

            var user = _users.FirstOrDefault(u => u.UserID == userID);
            if (user == null)
            {
                Console.WriteLine("User Not Found.");
                return;
            }

            if(user.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("The user has no borrowed books to return.");
                return;
            }

            Console.WriteLine($"\n Borrowed books for {user.Fname} {user.Lname}:");
            foreach( var book in user.BorrowedBooks)
            {
                Console.WriteLine($"- {book.Title} (ISBN: {book.ISBN})");
            }
            Console.Write("\nEnter the ISBN of the book to return: ");
            string isbnToReturn = Console.ReadLine();

            var bookToReturn = user.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbnToReturn);
            if (bookToReturn == null)
            {
                Console.WriteLine(" This book is not in the user's borrowed list.");
                return;
            }

            user.BorrowedBooks.Remove(bookToReturn);
            bookToReturn.AvailableCopies++;

            Console.WriteLine($" Book '{bookToReturn.Title}' successfully returned.");
        }

        public void GenerateReport()
        {
            Console.WriteLine("\n Library Report");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Books:");
            foreach (var book in _books)
            {
                int borrowed = book.TotalCopies - book.AvailableCopies;
                Console.WriteLine($"- {book.Title} (ISBN: {book.ISBN})");
                Console.WriteLine($"  Total: {book.TotalCopies}, Borrowed: {borrowed}, Available: {book.AvailableCopies}");
            }

            Console.WriteLine("\nUsers and Borrowed Books:");
            foreach (var user in _users)
            {
                Console.WriteLine($"\n {user.Fname} {user.Lname} (ID: {user.UserID})");
                if (user.BorrowedBooks.Count == 0)
                {
                    Console.WriteLine("  No books borrowed.");
                }
                else
                {
                    foreach (var b in user.BorrowedBooks)
                    {
                        Console.WriteLine($"  - {b.Title} (ISBN: {b.ISBN})");
                    }
                }
            }
            Console.WriteLine(new string('-', 60));
        }

    }

}

