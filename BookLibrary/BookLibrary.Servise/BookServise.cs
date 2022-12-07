using BookLibrary.DataAccess;
using BookLibrary.Entities;
using FluentValidation.Results;

namespace BookLibrary.Servise
{
    public static class BookServise
    {
        public static void AddBook()
        {
            var libId = ChooseLibraryId();
            if (libId > 0)
                TryToAddBook(libId);
        }
        public static void PrintAllBooks()
        {
            var libId = ChooseLibraryId();
            if (libId > 0)
                PrintLibraryBooks(libId);
        }
        private static int ChooseLibraryId()
        {
            Repository<LibrariesEntities> _libraries = new Repository<LibrariesEntities>();
            LibrariesEntities library;
            bool continueProg = true;
            int libId = 0;
            do
            {
                Console.WriteLine("Choose library Id or (-out) for exit");
                string input = Console.ReadLine();
                if (input == "-out")
                    continueProg = false;
                else
                {
                    int id;
                    if (Int32.TryParse(input, out id))
                    {
                        library = _libraries.Get(id);
                        if (library == null)
                        {
                            libId = 0;
                            Console.WriteLine("Library doesn't exist, try to choose again");
                        }
                        else
                        {
                            libId = library.Id;
                            continueProg = false;
                        }
                    }
                    else
                        Console.WriteLine("Invalid library Id, try to choose again");
                }
            }
            while (continueProg);

            return libId;
        }
        private static void TryToAddBook(int Id)
        {
            BookEntities _book = new BookEntities();

            _book.Title = GetFromConcole("Enter Title:");
            _book.Author = GetFromConcole("Enter Author:");
            _book.Description = GetFromConcole("Enter Description:");
            _book.Year = Int32.Parse(GetFromConcole("Enter Year:"));
            _book.LibraryId = Id;
            BookValidator validator = new BookValidator();

            ValidationResult results = validator.Validate(_book);
            if (results.IsValid)
            {
                Repository<BookEntities> _books = new Repository<BookEntities>();
                _books.Insert(_book);
                Console.WriteLine($"New book {_book.Title} added");
            }
            else
            {
                Console.WriteLine(results.ToString());
            }
        }
        private static string GetFromConcole(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        private static void PrintLibraryBooks(int libId)
        {
            Repository<BookEntities> _books = new Repository<BookEntities>();
            var filtredBooks = _books.GetAll().Where(b => b.LibraryId.Equals(libId)).ToList();
            if (filtredBooks.Any())
                Print(filtredBooks);
            else
                Console.WriteLine("Library is empty");
        }
        public static void Print(List<BookEntities> books)
        {
            books.ForEach(b => Console.WriteLine($"[{b.Id}] {b.Title} - author: {b.Author}, {b.Year}. {b.Description}"));
        }
    }
}