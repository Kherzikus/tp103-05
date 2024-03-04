namespace SmurfManagement.Fundamentals;

public class DiscRentable : Disc, IRentableItem
{
    private uint _id;
    private Smurf _listener;

    
    public DiscRentable(Disc disc, uint id, Librarian listener)
        : base(disc)
    {
        _id = id;
        _listener = listener;
        listener.AddItem(this);
    }

    
    public uint GetId()
    {
        return _id;
    }

    
    public Smurf GetOwner()
    {
        return _listener;
    }

    
    public void Rent(Villager villager)
    {
        if (_listener is Librarian)
        {
            _listener.ReturnItem(this);
            villager.RentItem(this);
            _listener = villager;
        }
        else
        {
            throw new ArgumentException("The disc is not available for rent.");
        }
    }

    
    public void Return(Librarian librarian)
    {
        if (_listener is Villager)
        {
            _listener.RentItem(this);
            librarian.AddItem(this);
            _listener = librarian;
        }
        else
        {
            throw new ArgumentException("The disc cannot be returned.");
        }
    }

    
    public override string Summary()
    {
        return $"DiscRentable [{_id}] owned by {_listener.Name}: {base.Summary()}";
    }
}