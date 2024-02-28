using Microsoft.Data.SqlClient;

namespace TrainingFPT
{
    public class Database
    {
        public static string GetConnection()
        {
            string connection = "Data Source=DUNG-PHAM-2209\\SQLEXPRESS;Initial Catalog=training;Integrated Security=True;Trust Server Certificate=True";
            return connection;
        }

        public static SqlConnection ConnectionDB()
        {
            string connectionString = Database.GetConnection();
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
