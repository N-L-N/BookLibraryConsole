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
            int year = Console.ReadLine() is string yearInput && int.TryParse(yearInput, out int parsedYear) ? parsedYear : 0;
            if (title != null && author != null)
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
            Console.WriteLine("Введите название книги для удаления:");
            string? bookTitle = Console.ReadLine();
            if (bookTitle != null)
            {
                library.RemoveBookForTitle(bookTitle);
                Console.WriteLine($"Книга '{bookTitle}' удалена из библиотеки.");
            }
            else
            {
                Console.WriteLine("Некорректный ввод названия книги.");
            }
            break;
        case "3":
            Console.WriteLine("Введите имя автора:");
            string? authorName = Console.ReadLine();
            if (authorName != null)
            {
                List<Book> foundBooks = library.SearchOfAuthor(authorName);

                foreach (var foundBook in foundBooks)
                {
                    Console.WriteLine($"Книга найдена: {foundBook.Title} - {foundBook.Author} ({foundBook.Year})");
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
                int index = 0;
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"{index}. {book.Title} - {book.Author} ({book.Year})");
                    index++;
                }
            }
            break;
        case "5":
            Console.WriteLine("Выход из программы.");
            return;
    }
    Console.WriteLine("Нажмите любую клавишу для продолжения...");
    Console.ReadKey(); 
    Console.Clear();
}
