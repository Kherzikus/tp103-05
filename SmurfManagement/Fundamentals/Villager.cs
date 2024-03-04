namespace SmurfManagement.Fundamentals;

public class Villager : Smurf
{
    public Villager(string name) : base(name) { }
    
    
    public override bool RentItem(IRentableItem item)
    {
        if (!Items.Contains(item))
        {
            if (item.GetOwner() == this)
            {
                Items.Add(item);
                return true;
            }
        }
        
        return false;
    }
    
    
    public override bool ReturnItem(IRentableItem item)
    {
        if (item.GetOwner() == this)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                return true;
            }
        }

        return false;
    }
}