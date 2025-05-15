using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public Book(string title, string author, string isbn, int totalCopies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            TotalCopies = totalCopies;
            AvailableCopies = totalCopies;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} | ISBN: {ISBN} | Available: {AvailableCopies}/{TotalCopies}";
        }
    }
}
