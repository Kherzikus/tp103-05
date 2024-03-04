namespace SmurfManagement.Fundamentals;

public interface IRentableItem
{
    public uint GetId();
    public Smurf GetOwner();
    public void Rent(Villager villager);
    public void Return(Librarian librarian);
    public string Summary();
}