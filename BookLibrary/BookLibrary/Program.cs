using BookLibrary.DataAccess;
using BookLibrary.Entities;
using BookLibrary.Servise;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continueProg = true;
            do
            {
                Console.WriteLine("Choose operation (-lib_c) - create library, (-lib_list) - print all libraries, (-book_c) - create book, (-book_list) - print all books, (-out) - exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "-lib_c":
                        LibraryServise.AddLibrary();
                        break;
                    case "-lib_list":
                        LibraryServise.PrintAllLibraries();
                        break;
                    case "-book_c":
                        BookServise.AddBook();
                        break;
                    case "-book_list":
                        BookServise.PrintAllBooks();
                        break;
                    case "-out":
                        continueProg = false;
                        break;
                    default:
                        continue;
                }
            }
            while (continueProg);

        }
    }
}