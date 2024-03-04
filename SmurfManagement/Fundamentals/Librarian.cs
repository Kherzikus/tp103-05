namespace SmurfManagement.Fundamentals;

public class Librarian : Smurf
{
    public Librarian(string name) : base(name) { }
    
    
    public void AddItem(IRentableItem rentableItem)
    {
        Items.Add(rentableItem);
    }
    
    
    public override bool RentItem(IRentableItem item)
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
    
    
    public override bool ReturnItem(IRentableItem item)
    {
        if (item.GetOwner() == this)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
                return true;
            }
        }

        return false;
    }
}