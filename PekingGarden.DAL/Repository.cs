using Microsoft.Data.SqlClient;

namespace PekingGarden.DAL;

public abstract class Repository
{
    private readonly string connectionString;
    
    protected Repository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected SqlConnection OpenConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}