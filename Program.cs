using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n" + new string('*', 60));
                Console.WriteLine("*               Welcome to Book Manager System             *");
                Console.WriteLine(new string('*', 60));

                Console.WriteLine("\nPlease choose from the options below:\n");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("| 1. Add Book                             |");
                Console.WriteLine("| 2. Remove Book                          |");
                Console.WriteLine("| 3. List Book                            |");
                Console.WriteLine("| 4. Add User                             |");
                Console.WriteLine("| 5. Borrow Book                          |");
                Console.WriteLine("| 6. Return Book                          |");
                Console.WriteLine("| 7. Generate Report                      |");
                Console.WriteLine("| 8. Exit                                 |");
                Console.WriteLine("-------------------------------------------");
                Console.Write("\nYour selection: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.AddBook();
                        break;

                    case "2":
                        library.RemoveBook();
                        break;

                    case "3":
                        library.ListBooks();
                        break;

                    case "4":
                        library.AddUser();
                        break;

                    case "5":
                        library.BorrowBook();
                        break;

                    case "6":
                        library.ReturnBook();
                        break;

                    case "7":
                        library.GenerateReport();
                        break;

                    case "8":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}