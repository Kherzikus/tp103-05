namespace SmurfManagement.Fundamentals;

public abstract class Smurf
{
    public string Name { get; }
    public List<IRentableItem> Items { get; }

    protected Smurf(string name)
    {
        Name = name;
        Items = new List<IRentableItem>();
    }
    
    public abstract bool RentItem(IRentableItem item);
    public abstract bool ReturnItem(IRentableItem item);
    
    public bool HasItem(uint itemId)
    {
        foreach (var item in Items)
        {
            if (item.GetId() == itemId)
            {
                return true;
            }
        }
        return false;
    }
}