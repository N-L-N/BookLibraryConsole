using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryConsole.LibraryBook
{
    public class Library
    {
        private readonly List<Book> books = [];

        public Library(Book book)
        {
            books.Add(book);
        }

        public Library() { }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBookForTitle(string title)
        {
            books.RemoveAll(b => b.Title == title.Trim());
        }

        public List<Book> SearchOfAuthor(string author)
        { 
            List<Book> foundBooks = [];
            for (int i = 0; i < books.Count; i++) {
                if (books[i].Author == author.Trim())
                {
                    foundBooks.Add(books[i]);
                }
            }
            return foundBooks;
        }

        public List<Book> GetAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Нет книг в библиотеке.");
                return [];
            }
            else
            {
                return books;
            }
        }
    }
}
