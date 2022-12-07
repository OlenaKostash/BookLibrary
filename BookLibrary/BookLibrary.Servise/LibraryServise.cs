using BookLibrary.DataAccess;
using BookLibrary.Entities;
using FluentValidation.Results;


namespace BookLibrary.Servise
{
    public static class LibraryServise
    {
        public static void AddLibrary()
        {
            var continueProg = true;
            do
            {
                Console.WriteLine("Enter name of library or (-out) for exit");
                string input = Console.ReadLine();

                if (input == "-out")
                {
                    continueProg = false;
                }
                else
                {
                    TryToAddLibrary(input);
                }
            }
            while (continueProg);        
        }

        private static void TryToAddLibrary(string input)
        {  
            LibrariesEntities _library = new LibrariesEntities();

            _library.Name = input;
            LibraryValidator validator = new LibraryValidator();

            ValidationResult results = validator.Validate(_library);
            if (results.IsValid)
            {
                Repository<LibrariesEntities> _libraries = new Repository<LibrariesEntities>();
                _libraries.Insert(_library);
                Console.WriteLine($"New library {_library.Name} added");
            }
            else
            {
                Console.WriteLine(results.ToString());
            }
        }

        public static void PrintAllLibraries()
        {
            var listOfLibraries = GetAllLibraries();
            Print(listOfLibraries.ToList());
        }

        private static IList<LibrariesEntities> GetAllLibraries()
        {
            Repository<LibrariesEntities> _libraries = new Repository<LibrariesEntities>();
            return _libraries.GetAll();
        }
        private static void Print(List<LibrariesEntities> librares)
        {
            librares.ForEach(lib => Console.WriteLine($"[{lib.Id}] {lib.Name}"));
        }
    }
}
