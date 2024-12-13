namespace Mockbuster;

public class library
{
    List<item> _items = new List<item>();
    public void addItems(item item)
    {
        _items.Add(item);
    }
    public void removeItems(item item)
    {
        _items.Remove(item);
    }
    public void viewItem()
    {
        foreach (item item in _items)
        {
            Console.WriteLine(item.title);
        }
    }
    public void borrowItem(item item)
    {
        item.isBorrowed = true;
    }
    public void returnItem(item item)
    {
        item.isBorrowed = false;
    }
}