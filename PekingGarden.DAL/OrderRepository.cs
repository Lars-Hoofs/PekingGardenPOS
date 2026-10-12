using Microsoft.Data.SqlClient;
using PekingGarden.Domain;
using PekingGarden.Logic.Interfaces;

namespace PekingGarden.DAL;

public class OrderRepository : Repository, IOrderRepository
{
    private const string SelectOrders = @"
        SELECT o.Id, o.OpenedAt, o.ClosedAt, t.Id AS TableId, t.Name, t.IsDrinksBill
        FROM TableOrder o
        JOIN DiningTable t ON t.Id = o.DiningTableId";

    public OrderRepository(string connectionString) : base(connectionString)
    {
    }

    public List<Order> GetOpenOrders()
    {
        using SqlConnection connection = OpenConnection();
        using SqlCommand command = new SqlCommand(SelectOrders + " WHERE o.ClosedAt IS NULL", connection);
        return LoadOrders(command);
    }

    private static List<Order> LoadOrders(SqlCommand command)
    {
        List<Order> orders = new List<Order>();
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            DateTime? closedAt = null;
            if (reader["ClosedAt"] != DBNull.Value)
            {
                closedAt = (DateTime)reader["ClosedAt"];
            }

            DiningTable table = new DiningTable(
                (int)reader["TableId"], (string)reader["Name"], (bool)reader["IsDrinksBill"]);
            orders.Add(new Order((int)reader["Id"], table, (DateTime)reader["OpenedAt"], closedAt));
        }
        return orders;
    }
}