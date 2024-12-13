namespace Mockbuster;

public class book : item
{
    string author;
    string isbn;
    public book(string title, string author, string isbn) : base(title)
    {
        this.author = author;
        this.isbn = isbn;
    }
    
}