namespace Mockbuster;

public class Dvd : Item
{
    string director;
    int duration; // in minutes
    public Dvd(string title, string director, int duration) : base(title)
    {
        this.director = director;
        this.duration = duration;
    }

}