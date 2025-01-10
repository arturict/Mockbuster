using System.Runtime.InteropServices.JavaScript;

namespace Mockbuster;

class Program
{
    static void Main(string[] args)
    {
        //TODO: Implement the main loop of the program
        Console.WriteLine("Welcome to Mockbuster!");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("Create (1), View (2), leave (l), Quit (q)");
        string input = Console.ReadLine();
        library lib = new library();
        switch (input.toLowerCase())
        { 
            case "1":
                Create();
                break;
            case "2":
                view();
                break;
            case "l":
                break;
            case "q":
                Environment.Exit(0);
                break;
                
                
            
        }

        public void Create()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("Create Item (1), Create User (2), leave (l), Quit (q)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Please enter the title of the item:");
                    string title = Console.ReadLine();
                    item item = new item(title);
                    lib.AddItems(item);
                    break;
                case "2":
                    Console.WriteLine("Please enter the name of the user:");
                    string name = Console.ReadLine();
                    user user = new user(name);
                    break;
            }
        }
        public void createItem()
        {
            Console.WriteLine("Do you want to create a DVD (1) or a Book (2), leave (l), Quit (q)? ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Please enter the title of the DVD:");
                    string title = Console.ReadLine();
                    item item = new item(title);
                    lib.AddItems(item);
                    break;
                case "2":
                    Console.WriteLine("Please enter the title of the book:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Please enter the author of the book:");
                    string author = Console.ReadLine();
                    Console.WriteLine("Please enter the ISBN of the book:");
                    string isbn = Console.ReadLine();
                    book book = new book(title, author, isbn);
                    lib.AddItems(book);
                    break;
            }
        }

        public void view()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("View Items (1), View Borrowed Items (2), View Available Items (3), leave (l), Quit (q)");
            string viewInput = Console.ReadLine();
            switch (viewInput)
            {
                case "1":
                    lib.ViewItem();
                    break;
                case "2":
                    lib.ViewBorrowedItems();
                    break;
                case "3":
                    lib.ViewAvailableItems();
                    break;
            }
        }





    }
}
