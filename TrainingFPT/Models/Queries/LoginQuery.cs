using Microsoft.Data.SqlClient;


namespace TrainingFPT.Models.Queries
{
    public class LoginQuery
    {
        public LoginViewModel CheckUserLogin(string username = "", string password = "")
        {
            LoginViewModel user = new LoginViewModel();

            using (SqlConnection conn = Database.ConnectionDB())
            {
                string sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Username", username ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", password ?? (object)DBNull.Value);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Id = reader["Id"].ToString();
                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Phone = reader["Phone"].ToString();
                        user.Address = reader["Address"].ToString();
                        user.RolesId = reader["RolesId"].ToString();
                    }
                    conn.Close();
                }
            }

            return user;
        }
    }
}
