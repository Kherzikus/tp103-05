namespace SmurfManagement.Fundamentals;

public class Library
{
    private uint _nextItemId;
    public uint NextItemId
    {
        get { return _nextItemId; }
        set { _nextItemId = value; }
    }

    public uint Day { get; private set; }
    public Dictionary<(uint shelfId, uint position), IRentableItem> Items { get; } = new Dictionary<(uint, uint), IRentableItem>();
    public List<RentableInfo> RentableInfos { get; } = new List<RentableInfo>();

    
    public Library()
    {
        _nextItemId = 0;
        Day = 0;
        Items.Clear();
        RentableInfos.Clear();
    }
    
    
    public uint GetNextItemId()
    {
        return _nextItemId++;
    }
    
    
    public (uint shelfId, uint position) GetLocation(string name)
    {
        ulong h = 0;
        int bitsSize = sizeof(ulong) * 8;

        foreach (char c in name)
        {
            h = h << (bitsSize / 8) + c;
            ulong high = h >> (bitsSize * 7 / 8);
                
            if (high != 0)
            {
                h ^= (high >> (bitsSize * 7 / 8));
            }

            h &= ~high;
        }

        uint shelfId = (uint)(h >> 32);
        uint position = (uint)h;

        return (shelfId, position);
    }
    
    
    public RentableInfo BuyItem(Item item, uint maxRentDays, Librarian librarian)
    {
        if (item is IRentableItem existingRentable)
        {
            throw new ArgumentException("Item is already a rentable item.");
        }

        if (!(item is Book || item is Disc))
        {
            throw new Exception("Unsupported item type.");
        }

        IRentableItem newRentable;
        uint itemId = GetNextItemId();

        if (item is Book book)
        {
            newRentable = new BookRentable(book, itemId, librarian);
        }
        else if (item is Disc disc)
        {
            newRentable = new DiscRentable(disc, itemId, librarian);
        }
        else
        {
            throw new Exception("Unsupported item type.");
        }

        (uint shelfId, uint position) location = GetLocation(item.Name);

        Items.Add(location, newRentable);

        RentableInfo rentableInfo = new RentableInfo(itemId, librarian, maxRentDays, location);
        RentableInfos.Add(rentableInfo);

        librarian.AddItem(newRentable);

        return rentableInfo;
    }
    
    
    public void RentItem(Villager villager, uint itemId, uint days)
    {/*
        if (days == 0)
        {
            throw new ArgumentException("Le loyer doit durer au moins une journée");
        }

        RentableInfo rentableInfo = RentableInfos.FirstOrDefault(info => info.ItemId == itemId);

        if (rentableInfo == null)
        {
            throw new ArgumentException("Article non trouvé");
        }

        if (rentableInfo.InCharge != villager)
        {
            throw new ArgumentException("Objet déjà loué");
        }

        if (days > rentableInfo.MaxRentDays)
        {
            throw new ArgumentException("Les jours de loyer dépassent les jours de loyer maximum");
        }

        uint remainingDays = rentableInfo.MaxRentDays - (uint)(Day - rentableInfo.RentDay);

        if (days > remainingDays)
        {
            throw new ArgumentException("Les jours de loyer dépassent les jours restants pour la location");
        }

        IRentableItem rentableItem = Items[rentableInfo.Location];
        rentableItem.Rent(villager);
        rentableInfo.RentDay = Day;
        rentableInfo.RentDaysLeft = remainingDays - days;
    */}
    
    
    public string NextDay()
    {
        string result = $"Day {Day}\n";

        foreach (var rentableInfo in RentableInfos.Where(info => info.RentDay != null))
        {
            rentableInfo.RentDaysLeft--;

            if (rentableInfo.RentDaysLeft == 0)
            {
                IRentableItem rentableItem = Items[rentableInfo.Location];
                result += rentableItem.Summary() + "\n\n";
                RentableInfos.Remove(rentableInfo);
                Items.Remove(rentableInfo.Location);
            }
        }

        Day++;

        return result;
    }
}