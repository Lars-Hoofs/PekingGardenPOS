using PekingGarden.Domain;

namespace PekingGarden.Logic;

public class TableStatus
{
    public DiningTable Table { get; }
    public Order? Order { get; }
    
    public bool IsOpen => Order != null;

    public TableStatus(DiningTable table, Order order)
    {
        Table = table;
        Order = order;
    }
}