namespace PekingGarden.Domain;

public class Order
{
    public int Id { get; }
    public DiningTable Table { get; }
    public DateTime OpenedAt { get; }
    public DateTime? ClosedAt { get; private set; }
    
    public bool IsClosed => ClosedAt != null;

    public Order(int id, DiningTable table, DateTime openedAt, DateTime? closedAt)
    {
        Id = id;
        Table = table;
        OpenedAt = openedAt;
        ClosedAt = closedAt;
        
    }
}