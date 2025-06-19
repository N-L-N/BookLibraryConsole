using BookLibraryConsole.LibraryBook;

Library library = new();

while (true)
{
    Console.WriteLine("Добро пожаловать в библиотеку!\n");

    Console.WriteLine("1. Добавить книгу\n2. Удалить книгу\n3. Найти по автору\n4. Показать все книги.\n5. Выйти");

    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Введите название книги:");
            string? title = Console.ReadLine();
            Console.WriteLine("Введите автора книги:");
            string? author = Console.ReadLine();
            Console.WriteLine("Введите год издания книги:");
            string? year = Console.ReadLine();
            if (title != null && author != null && year != null)
            {
                Book book = new Book(title, author, year);
                library.AddBook(book);
                Console.WriteLine($"Книга '{title}' добавлена в библиотеку.");
            }
            else
            {
                Console.WriteLine("Некорректный ввод данных.");
            }
            break;
        case "2":
            Console.WriteLine("Введите id книги (начинается с 0): ");
            if (int.TryParse(Console.ReadLine(), out int id) && id >= 0)
            {
                try
                {
                    library.RemoveBook(id);
                    Console.WriteLine($"Книга с id {id} удалена из библиотеки.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Книга с таким id не найдена.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод id.");
            }
            break;
        case "3":
            Console.WriteLine("Введите имя автора:");
            string? authorName = Console.ReadLine();
            if (authorName != null)
            {
                Book? foundBook = library.SearchOfAuthor(authorName);
                if (foundBook != null)
                {
                    Console.WriteLine($"Книга найдена: {foundBook.Title} - {foundBook.Author} ({foundBook.Year})");
                }
                else
                {
                    Console.WriteLine("Книги с таким автором не найдены.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод имени автора.");
            }
            break;
        case "4":
            List<Book> allBooks = library.GetAllBooks();
            if (allBooks.Count > 0)
            {
                Console.WriteLine("Список всех книг в библиотеке:");
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} ({book.Year})");
                }
            }
            break;
        case "5":
            Console.WriteLine("Выход из программы.");
            return;
    }
}
