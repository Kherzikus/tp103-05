namespace SmurfManagement.Fundamentals;
    
public abstract class Item
{
    public string Name { get; }
    public string ReleaseDate { get; }

    
    protected Item(string name, string releaseDate)
    {
        Name = name;
        ReleaseDate = releaseDate;
    }

    
    protected Item(Item item)
    {
        Name = item.Name;
        ReleaseDate = item.ReleaseDate;
    }
    
    
    public virtual string Summary()
    {
        return $"{Name}, released on {ReleaseDate}";
    }
}