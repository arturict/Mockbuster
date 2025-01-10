namespace Mockbuster;

public class Book : Item
{
    string author;
    string isbn; // International Standard Book Number
    public Book(string title, string author, string isbn) : base(title)
    {
        this.author = author;
        this.isbn = isbn;
    }
    
}