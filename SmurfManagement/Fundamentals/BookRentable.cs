namespace SmurfManagement.Fundamentals;

public class BookRentable : Book, IRentableItem
{
    private uint _id;
    private Smurf _reader;

    
    public BookRentable(Book book, uint id, Librarian reader)
        : base(book)
    {
        _id = id;
        _reader = reader;
        reader.AddItem(this);
    }

    
    public uint GetId()
    {
        return _id;
    }

    
    public Smurf GetOwner()
    {
        return _reader;
    }

    
    public void Rent(Villager villager)
    {
        if (_reader is Librarian)
        {
            _reader.ReturnItem(this);
            villager.RentItem(this);
            _reader = villager;
        }
        else
        {
            throw new ArgumentException("The book is not available for rent.");
        }
    }
    

    public void Return(Librarian librarian)
    {
        if (_reader is Villager)
        {
            _reader.RentItem(this);
            librarian.AddItem(this);
            _reader = librarian;
        }
        else
        {
            throw new ArgumentException("The book cannot be returned.");
        }
    }

    
    public override string Summary()
    {
        return $"BookRentable [{_id}] owned by {_reader.Name}: {base.Summary()}";
    }
}