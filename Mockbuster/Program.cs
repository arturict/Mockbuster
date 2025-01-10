namespace Mockbuster
{
    internal class Program
    {
        private static List<User> _users = new List<User>();
        private static Library _lib = new Library();
        
        private User _loggedInUser;

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
            Console.WriteLine("Create (1), View (2), Login (u), leave (l), Quit (q)");

            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "1":
                    ShowCreateMenu();
                    break;
                case "2":
                    ShowViewMenu();
                    break;
                case "u":
                    ShowLoginMenu();
                    break;
                case "l":
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
                    CreateUser();
                    break;
                case "l":
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
            while (true)
            {
                Console.WriteLine("Möchtest du eine DVD (1) oder ein Buch (2) erstellen, leave (l), Quit (q)?");
                string input = Console.ReadLine()?.ToLower();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Bitte gib den Titel der DVD ein:");
                        string dvdTitle = Console.ReadLine();
                        Console.WriteLine("Bitte gib den Director der DVD ein:");
                        string director = Console.ReadLine();
                        Console.WriteLine("Bitte gib die Dauer (in Minuten) ein:");
                        int duration = int.Parse(Console.ReadLine() ?? "0");
                        var dvdItem = new Dvd(dvdTitle, director, duration);
                        _lib.AddItems(dvdItem);
                        Console.WriteLine("DVD erfolgreich erstellt.");
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
                        Console.WriteLine("Buch erfolgreich erstellt.");
                        break;
                    case "l":
                        return;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        continue;
                }

                Console.WriteLine("Möchtest du noch ein Item erstellen? (j/n)");
                string more = Console.ReadLine()?.ToLower();
                if (more != "j") break;
            }
        }

        private void CreateUser()
        {
            while (true)
            {
                Console.WriteLine("Bitte gib den Namen des Users ein:");
                string name = Console.ReadLine();

                var user = new User(name);
                _users.Add(user);
                Console.WriteLine("User erfolgreich erstellt.");

                Console.WriteLine("Möchtest du noch einen User erstellen? (j/n)");
                string more = Console.ReadLine()?.ToLower();
                if (more != "j") break;
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
            Console.Clear();

            while (true)
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
                        return;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        continue;
                }

                Console.WriteLine("Möchtest du noch etwas anderes anschauen? (j/n)");
                string more = Console.ReadLine()?.ToLower();
                if (more != "j") break;
                Console.Clear();
            }
        }

        private void ViewUsers()
        {
            Console.Clear();

            while (true)
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
                        return;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        continue;
                }

                Console.WriteLine("Möchtest du noch etwas anderes anschauen? (j/n)");
                string more = Console.ReadLine()?.ToLower();
                if (more != "j") break;
                Console.Clear();
            }
        }

        private void ShowLoginMenu()
        {
            if (_users.Count == 0)
            {
                Console.WriteLine("Keine User vorhanden. Lege zuerst einen User an.");
                return;
            }

            Console.WriteLine("Gib bitte den Usernamen ein, um dich einzuloggen:");
            string username = Console.ReadLine();
            
            var foundUser = _users.Find(u => u.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (foundUser == null)
            {
                Console.WriteLine("User nicht gefunden.");
                return;
            }

            _loggedInUser = foundUser;
            Console.WriteLine($"Eingeloggt als: {_loggedInUser.Name}");
            ShowLoggedInUserMenu();
        }

        private void ShowLoggedInUserMenu()
        {
            while (_loggedInUser != null)
            {
                Console.WriteLine("Bitte wähle eine Option:");
                Console.WriteLine("Borrow Item (1), Return Item (2), Logout (l), Quit (q)");
                string input = Console.ReadLine()?.ToLower();

                switch (input)
                {
                    case "1":
                        BorrowItemForUser(_loggedInUser);
                        break;
                    case "2":
                        ReturnItemForUser(_loggedInUser);
                        break;
                    case "l":
                        Console.WriteLine($"Du hast dich ausgeloggt (User: {_loggedInUser.Name}).");
                        _loggedInUser = null;
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        break;
                }
                
                if (_loggedInUser == null) break;
            }
        }

        private void BorrowItemForUser(User user)
        {
            // Show all available items before borrowing
            var availableItems = _lib.GetAvailableItems(); 
            if (availableItems.Count == 0)
            {
                Console.WriteLine("Es sind keine Items verfügbar.");
                return;
            }
            Console.WriteLine("Verfügbare Items:");
            foreach (var item in availableItems)
            {
                Console.WriteLine($"- {item.Title}");
            }

            Console.WriteLine("Welches Item möchtest du ausleihen? (Titel eingeben oder 'abbrechen')");
            string title = Console.ReadLine();

            if (title?.ToLower() == "abbrechen") return;

            var itemToBorrow = _lib.GetItemByTitle(title);
            if (itemToBorrow == null)
            {
                Console.WriteLine("Item nicht gefunden.");
                return;
            }

            if (!_lib.IsItemAvailable(itemToBorrow))
            {
                Console.WriteLine("Dieses Item ist bereits ausgeliehen.");
                return;
            }

            user.BorrowItem(itemToBorrow);
            _lib.MarkAsBorrowed(itemToBorrow);
        }

        private void ReturnItemForUser(User user)
        {
            Console.WriteLine("Welches Item möchtest du zurückgeben? (Titel eingeben oder 'abbrechen')");
            string title = Console.ReadLine();

            if (title?.ToLower() == "abbrechen") return;

            var borrowedItem = user.GetBorrowedItemByTitle(title);
            if (borrowedItem == null)
            {
                Console.WriteLine("Du hast kein Item mit diesem Titel ausgeliehen.");
                return;
            }

            user.ReturnItem(borrowedItem);
            _lib.MarkAsReturned(borrowedItem);
        }
    }
}
