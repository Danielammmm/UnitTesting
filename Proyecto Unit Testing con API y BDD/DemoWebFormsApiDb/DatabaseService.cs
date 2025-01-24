using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService()
    {
        // Obtén la cadena de conexión desde el archivo Web.config
        _connectionString = WebConfigurationManager.ConnectionStrings["DemoDb"].ConnectionString;
    }

    public IEnumerable<string> GetAllNames()
    {
        var names = new List<string>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT Name FROM SampleTable", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                names.Add(reader.GetString(0)); // Lee el valor de la columna "Name"
            }
        }
        return names;
    }
}
