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

        public void RemoveBook(int id)
        {
            books.RemoveAt(id);
        }

        public Book? SearchOfAuthor(string author)
        { 
            for (int i = 0; i < books.Count; i++) {
                if (books[i].Author == author.Trim())
                {
                    return books[i];
                }
            }
            return null;
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
