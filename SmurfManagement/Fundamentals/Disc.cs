namespace SmurfManagement.Fundamentals;

public class Disc : Item
{
    public uint Duration { get; }
    public string Genre { get; }

    
    public Disc(string name, string releaseDate, uint duration, string genre)
        : base(name, releaseDate)
    {
        if (duration == 0)
        {
            throw new ArgumentException("Duration must be greater than 0.");
        }

        Duration = duration;
        Genre = genre;
    }

    
    public Disc(Disc disc)
        : base(disc)
    {
        Duration = disc.Duration;
        Genre = disc.Genre;
    }

    
    public static Disc operator +(Disc disc1, Disc disc2)
    {
        if (disc1.Genre != disc2.Genre)
        {
            throw new ArgumentException("Both discs must have the same genre.");
        }

        string[] dateParts = DateTime.Now.ToString("yyyy-MM-dd").Split('-');
        string currentDate = $"{dateParts[0]}-{dateParts[1]}-{dateParts[2]}";

        string combinedName = $"{disc1.Name}, {disc2.Name}";
        uint combinedDuration = disc1.Duration + disc2.Duration;

        return new Disc(combinedName, currentDate, combinedDuration, disc1.Genre);
    }

    
    public override string Summary()
    {
        int hours = (int)(Duration / 3600);
        int minutes = (int)((Duration % 3600) / 60);
        int seconds = (int)(Duration % 60);

        string hoursStr = hours > 0 ? $"{hours} hour{(hours > 1 ? "s" : "")}, " : "";
        string minutesStr = minutes > 0 ? $"{minutes} minute{(minutes > 1 ? "s" : "")} " : "";
        string secondsStr = seconds > 0 ? $"{seconds} second{(seconds > 1 ? "s" : "")}" : "";

        string durationStr = $"{hoursStr}{minutesStr}{secondsStr}".TrimEnd();

        return $"{base.Summary()}, lasting {durationStr} and belonging to the {Genre} genre.";
    }
}