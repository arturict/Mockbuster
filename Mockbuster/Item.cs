namespace Mockbuster;

public class Item
{
    string _title;
    bool _isBorrowed;
    public string title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
    public bool isBorrowed
    {
        get
        {
            return _isBorrowed;
        }
        set
        {
            _isBorrowed = value;
        }
    }
    public Item(string title)
    {
        this.title = title;
        this.isBorrowed = false;
    }
    public void Borrow()
    {
        this.isBorrowed = true;
        Console.WriteLine($"Borrowing {title}");
    }
    public void ReturnItem()
    {
        this.isBorrowed = false;
        Console.WriteLine($"Returning {title}");
    }
}