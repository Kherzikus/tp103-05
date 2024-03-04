namespace SmurfManagement.Fundamentals;

public class RentableInfo
{
    public uint ItemId { get; }
    public Librarian InCharge { get; }
    public uint? RentDay { get; set; }
    public uint? RentDaysLeft { get; set; }
    public uint MaxRentDays { get; }
    public (uint shelfId, uint position) Location { get; }
    
    
    public RentableInfo(uint itemId, Librarian inCharge, uint maxRentDays, (uint shelfId, uint position) location)
    {
        if (maxRentDays == 0)
        {
            throw new ArgumentException("Maximum rent days must be greater than 0.");
        }

        ItemId = itemId;
        InCharge = inCharge;
        MaxRentDays = maxRentDays;
        Location = location;
    }
}