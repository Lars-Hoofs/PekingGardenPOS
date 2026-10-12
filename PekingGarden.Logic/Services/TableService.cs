using PekingGarden.Domain;
using PekingGarden.Logic.Interfaces;

namespace PekingGarden.Logic.Services;

public class TableService
{
    private readonly ITableRepository tableRepository;
    private readonly IOrderRepository orderRepository;

    public TableService(ITableRepository tableRepository, IOrderRepository orderRepository)
    {
        this.tableRepository = tableRepository;
        this.orderRepository = orderRepository;
    }

    public List<TableStatus> GetOverview()
    {
        List<Order> openOrders = orderRepository.GetOpenOrders();

        List<TableStatus> overview = new List<TableStatus>();
        foreach (DiningTable table in tableRepository.GetTables())
        {
            Order? order = openOrders.Find(openOrder => openOrder.Table.Id == table.Id);
            overview.Add(new TableStatus(table, order));
        }
        return overview;
    }
}