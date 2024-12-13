namespace Mockbuster;

public class dvd : item
{
    string director;
    int duration; // in minutes
    public dvd(string title, string director, int duration) : base(title)
    {
        this.director = director;
        this.duration = duration;
    }

}