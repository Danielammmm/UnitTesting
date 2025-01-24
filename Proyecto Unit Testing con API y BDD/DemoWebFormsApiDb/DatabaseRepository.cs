using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoWebFormsApiDb
{
    public class DatabaseRepository : IDataRepository
    {
        public DataTable GetAllUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DemoDb"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Name FROM SampleTable"; // Cambia 'Users' por tu tabla real
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al acceder a la base de datos: {ex.Message}");
            }
        }
    }
}
