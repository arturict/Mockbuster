namespace Mockbuster;

class Program
{
    static void Main(string[] args)
    {
        //TODO: Implement the main loop of the program
        library lib = new library();
        List<item> items = new List<item>
        {
            new dvd("Shrek", "Andrew Adamson", 90),
            new dvd("Cars", "John Lasseter", 117),
            new dvd("The Matrix", "The Wachowskis", 136),
            new book("The Subtle Art of Not Giving a F*ck", "Mark Manson", "978-0-06-245771-4"),
            new book("The 48 Laws of Power", "Robert Greene", "978-0-14-028019-7"),
            new book("Can't Hurt Me", "David Goggins", "978-1-9821-3344-5"),
            new book("Atomic Habits", "James Clear", "978-0-525-65000-3")
        };
        user artur = new user("Artur");
        user simon = new user("Simon");
        user yannick = new user("Yannick");
        user marvin = new user("Marvin");
      
        foreach (item item in items)
        {
            lib.AddItems(item);
        }
        artur.BorrowItem(lib.GetItemByTitle("The 48 Laws of Power"));
        artur.BorrowItem(lib.GetItemByTitle("The Subtle Art of Not Giving a F*ck"));
        simon.BorrowItem(lib.GetItemByTitle("Can't Hurt Me"));
        yannick.BorrowItem(lib.GetItemByTitle("The Matrix"));
        marvin.BorrowItem(lib.GetItemByTitle("Cars"));
        
        
        
        
    }
}
