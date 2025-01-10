namespace Mockbuster
{
    internal class Program
    {
        private static List<User> _users = new List<User>();

        private static Library _lib = new Library();

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            Console.WriteLine("Willkommen bei Mockbuster!");
            while (true)
            {
                ShowMainMenu();
            }
        }

        private void ShowMainMenu()
        {
            
            Console.WriteLine("Bitte wähle eine Option:");
            Console.WriteLine("Create (1), View (2), leave (l), Quit (q)");

            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "1":
                    ShowCreateMenu();
                    break;
                case "2":
                    ShowViewMenu();
                    break;
                case "l":
                    // Zurück zum Hauptmenü
                    ShowMainMenu();
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
        }

        private void ShowCreateMenu()
        {
            Console.WriteLine("Bitte wähle eine Option:");
            Console.WriteLine("Create Item (1), Create User (2), leave (l), Quit (q)");

            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "1":
                    CreateItem();
                    break;
                case "2":
                    Console.WriteLine("Bitte gib den Namen des Users ein:");
                    string name = Console.ReadLine();
                    var user = new User(name);

                    // Neu erstellten User in unsere lokale Liste einfügen
                    _users.Add(user);

                    Console.WriteLine("User erfolgreich erstellt");
                    break;
                case "l":
                    // Zurück zum Hauptmenü
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
        }

        private void CreateItem()
        {
            Console.WriteLine("Möchtest du eine DVD (1) oder ein Buch (2) erstellen, leave (l), Quit (q)?");
            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Bitte gib den Titel der DVD ein:");
                    string dvdTitle = Console.ReadLine();
                    var dvdItem = new Item(dvdTitle);
                    _lib.AddItems(dvdItem);
                    break;
                case "2":
                    Console.WriteLine("Bitte gib den Buchtitel ein:");
                    string bookTitle = Console.ReadLine();
                    Console.WriteLine("Bitte gib den Autor ein:");
                    string author = Console.ReadLine();
                    Console.WriteLine("Bitte gib die ISBN ein:");
                    string isbn = Console.ReadLine();
                    var newBook = new Book(bookTitle, author, isbn);
                    _lib.AddItems(newBook);
                    break;
                case "l":
                    // Zurück ins Create Menü
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
        }

        private void ShowViewMenu()
        {
            Console.WriteLine("Bitte wähle eine Option:");
            Console.WriteLine("View Items (1), View Users (2), leave (l), Quit (q)");
            string viewInput = Console.ReadLine()?.ToLower();

            switch (viewInput)
            {
                case "1":
                    ViewItems();
                    break;
                case "2":
                    ViewUsers();
                    break;
                case "l":
                    // Zurück zum Hauptmenü
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
        }

        private void ViewItems()
        {
            Console.WriteLine("Bitte wähle eine Option:");
            Console.WriteLine("View All Items (1), View Borrowed Items (2), View Available Items (3), leave (l), Quit (q)");
            string viewInput = Console.ReadLine()?.ToLower();

            switch (viewInput)
            {
                case "1":
                    _lib.ViewItem();
                    break;
                case "2":
                    _lib.ViewBorrowedItems();
                    break;
                case "3":
                    _lib.ViewAvailableItems();
                    break;
                case "l":
                    // Zurück ins View Menü
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
        }

        private void ViewUsers()
        {
            Console.WriteLine("Bitte wähle eine Option:");
            Console.WriteLine("View All Users (1), View Borrowed Items (2), View Available Items (3), leave (l), Quit (q)");
            string viewInput = Console.ReadLine()?.ToLower();

            switch (viewInput)
            {
                case "1":
                    if (_users.Count == 0)
                    {
                        Console.WriteLine("Keine User vorhanden.");
                    }
                    else
                    {
                        Console.WriteLine("Vorhandene User:");
                        foreach (var usr in _users)
                        {
                            Console.WriteLine($"• {usr.Name}");
                        }
                    }
                    break;
                case "2":
                    _lib.ViewBorrowedItems();
                    break;
                case "3":
                    _lib.ViewAvailableItems();
                    break;
                case "l":
                    // Zurück ins View Menü
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
        }
    }
}
