namespace PekingGarden.Domain;

public class DiningTable
{
    public int Id { get; }
    public string Name { get; }
    public bool IsDrinksBill { get; }

    public DiningTable(int id, string name, bool isDrinksBill)
    {
        Id = id;
        Name = name;
        IsDrinksBill = isDrinksBill;
    }
}