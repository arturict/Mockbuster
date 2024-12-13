namespace Mockbuster;

public class item
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
    public item(string title)
    {
        this.title = title;
        this.isBorrowed = false;
    }
    public void borrow()
    {
        this.isBorrowed = true;
    }
    public void returnItem()
    {
        this.isBorrowed = false;
    }
}