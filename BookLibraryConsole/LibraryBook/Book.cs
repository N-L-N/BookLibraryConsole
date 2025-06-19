using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryConsole.LibraryBook
{
    public class Book(string title, string author, string year)
    {
        public string Title { get; } = title;
        public string Author { get; } = author;
        public string Year { get; } = year;
    }
}
