using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class User
    {
        public string Fname {  get; set; }
        public string Lname { get; set; }
        public string UserID { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public User(string fname, string lname, string userID, List<Book> borrowedBooks)
        {
            Fname = fname;
            Lname = lname;
            UserID = userID;
            BorrowedBooks = borrowedBooks;
        }
    }
}
