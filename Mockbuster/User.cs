using Mockbuster;

class User
{
    public string Name { get; private set; }
    private List<Item> borrowedItems;

    public User(string name)
    {
        this.Name = name;
        this.borrowedItems = new List<Item>();
    }


    public void BorrowItem(Item item)
    {
        borrowedItems.Add(item);
        Console.WriteLine($"{Name} borrowed {item.title}");
    }

    public void ReturnItem(Item item)
    {
        borrowedItems.Remove(item);
        Console.WriteLine($"{Name} returned {item.title}");
    }

    public void ViewBorrowedItems()
    {
        foreach (Item item in borrowedItems)
        {
            Console.WriteLine(item.title);
        }
    }

    public Item GetBorrowedItemByTitle(string title)
    {
        string lowerTitle = title.ToLower();
        return borrowedItems
            .FirstOrDefault(i => i.title.ToLower() == lowerTitle);
    }

}