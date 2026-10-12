using Microsoft.Data.SqlClient;
using PekingGarden.Domain;
using PekingGarden.Logic.Interfaces;

namespace PekingGarden.DAL;

public class TableRepository : Repository, ITableRepository
{
    public TableRepository(string connectionString) : base(connectionString)
    {
    }

    public List<DiningTable> GetTables()
    {
        const string sql = "SELECT Id, Name, IsDrinksBill FROM DiningTable ORDER BY SortOrder";

        using SqlConnection connection = OpenConnection();
        using SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader reader = command.ExecuteReader();

        List<DiningTable> tables = new List<DiningTable>();
        while (reader.Read())
        {
            tables.Add(ReadTable(reader));
        }
        return tables;
    }

    public DiningTable? GetTable(int tableId)
    {
        const string sql = "SELECT Id, Name, IsDrinksBill FROM DiningTable WHERE Id = @tableId";

        using SqlConnection connection = OpenConnection();
        using SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@tableId", tableId);
        using SqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }
        return ReadTable(reader);
    }

    private static DiningTable ReadTable(SqlDataReader reader)
    {
        return new DiningTable((int)reader["Id"], (string)reader["Name"], (bool)reader["IsDrinksBill"]);
    }
}