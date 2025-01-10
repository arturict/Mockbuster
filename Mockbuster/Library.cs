using Mockbuster;

public class Library
{
    List<Item> _items = new List<Item>();

    public void AddItems(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItems(Item item)
    {
        _items.Remove(item);
    }

    public void ViewItem()
    {
        foreach (Item item in _items)
        {
            Console.WriteLine(item.title);
        }
    }

    public void BorrowItem(Item item)
    {
        item.isBorrowed = true;
    }

    public Item GetItemByTitle(string title)
    {
        return _items.FirstOrDefault(i => i.title == title);
    }

    public void ReturnItem(Item item)
    {
        item.isBorrowed = false;
    }

    public void ViewBorrowedItems()
    {
        foreach (Item item in _items)
        {
            if (item.isBorrowed)
            {
                Console.WriteLine(item.title);
            }
        }
    }

    public void ViewAvailableItems()
    {
        foreach (Item item in _items)
        {
            if (!item.isBorrowed)
            {
                Console.WriteLine(item.title);
            }
        }
    }

    // Neue Methoden, damit dein Programm vollständig läuft
    public List<Item> GetAvailableItems()
    {
        return _items.Where(i => !i.isBorrowed).ToList();
    }

    public bool IsItemAvailable(Item item)
    {
        return !item.isBorrowed;
    }

    public void MarkAsBorrowed(Item item)
    {
        item.isBorrowed = true;
    }

    public void MarkAsReturned(Item item)
    {
        item.isBorrowed = false;
    }
}