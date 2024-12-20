namespace Mockbuster;

public class library
{
    List<item> _items = new List<item>();
    public void AddItems(item item)
    {
        _items.Add(item);
    }
    public void RemoveItems(item item)
    {
        _items.Remove(item);
    }
    public void ViewItem()
    {
        foreach (item item in _items)
        {
            Console.WriteLine(item.title);
        }
    }
    public void BorrowItem(item item)
    {
        item.isBorrowed = true;
    }
    public item GetItemByTitle(string title)
    {
        return _items.FirstOrDefault(i => i.title == title);
    }
    public void ReturnItem(item item)
    {
        item.isBorrowed = false;
    }
    public void ViewBorrowedItems()
    {
        foreach (item item in _items)
        {
            if (item.isBorrowed)
            {
                Console.WriteLine(item.title);
            }
        }
    }
    public void ViewAvailableItems()
    {
        foreach (item item in _items)
        {
            if (!item.isBorrowed)
            {
                Console.WriteLine(item.title);
            }
        }
    }
}