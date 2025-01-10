namespace Mockbuster;
class User
{
    
    private string name;
    private List<Item> borrowedItems;
    public User(string name)
    {
        this.name = name;
        this.borrowedItems = new List<Item>();
    }
    public void BorrowItem(Item item)
    {
        borrowedItems.Add(item);
        Console.WriteLine($"{name} borrowed {item.title}");
    }
    public void ReturnItem(Item item)
    {
        borrowedItems.Remove(item);
        Console.WriteLine($"{name} returned {item.title}");
    }
    
}