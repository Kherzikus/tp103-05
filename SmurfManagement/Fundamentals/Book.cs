namespace SmurfManagement.Fundamentals;

public class Book : Item
{
    public string Author { get; }
    public uint NbPages { get; }
    public uint NbChapters { get; }
    public uint VolumeNumber { get; }

    
    public Book(string name, string releaseDate, string author, uint nbPages, uint nbChapters, uint volumeNumber)
        : base(name, releaseDate)
    {
        if (nbPages == 0 || nbChapters == 0 || volumeNumber == 0)
        {
            throw new ArgumentException("Number of pages, chapters, and volume number must be greater than 0.");
        }

        Author = author;
        NbPages = nbPages;
        NbChapters = nbChapters;
        VolumeNumber = volumeNumber;
    }

    
    public Book(Book book)
        : base(book)
    {
        Author = book.Author;
        NbPages = book.NbPages;
        NbChapters = book.NbChapters;
        VolumeNumber = book.VolumeNumber;
    }

    
    public override string Summary()
    {
        string volumeSuffix = GetVolumeSuffix(VolumeNumber);

        string pagesSuffix = NbPages > 1 ? "s" : "";
        string chaptersSuffix = NbChapters > 1 ? "s" : "";

        return $"{base.Summary()}, written by {Author}, consisting of {NbPages} page{pagesSuffix}, organized in {NbChapters} chapter{chaptersSuffix}, which is the {VolumeNumber}{volumeSuffix} volume.";
    }
    

    private static string GetVolumeSuffix(uint volumeNumber)
    {
        if (volumeNumber % 10 == 1 && volumeNumber % 100 != 11)
        {
            return "st";
        }
        if (volumeNumber % 10 == 2 && volumeNumber % 100 != 12)
        {
            return "nd";
        }
        if (volumeNumber % 10 == 3 && volumeNumber % 100 != 13)
        {
            return "rd";
        }
        
        return "th";
    }
}