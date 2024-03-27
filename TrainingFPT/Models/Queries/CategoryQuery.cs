using Microsoft.Data.SqlClient;


namespace TrainingFPT.Models.Queries
{
    public class CategoryQuery
    {
        public int AddCategory(string Name, string Description, string Poster, string status)
        {
            int lastId = 0;
            string sql = "INSERT INTO [Categories] ([Name], [Description], [Poster], [Status], [ParentId], [Created_at]) VALUES (@Name, @Description, @Poster, @Status, @ParentId, @Created_at); SELECT SCOPE_IDENTITY();";

            //using (SqlConnection conn = new SqlConnection())
            using (SqlConnection conn = Database.ConnectionDB())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", Name ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Description", Description ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Poster", Poster ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Status", status ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@ParentId", 0);
                cmd.Parameters.AddWithValue("@Created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                lastId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            return lastId;
        }

        public List<CategoryDetail> GetCategories(string? search, string? filterStatus)
        {
            Console.WriteLine("GetCategories", search);
            List<CategoryDetail> categories = new List<CategoryDetail>();
            string sqlData;
            using (SqlConnection conn = Database.ConnectionDB())
            {
                conn.Open();
                if (filterStatus != null)
                {
                    sqlData = "select * from [Categories] where [Name] like @search and [Status] = @Status and [Deleted_at] is null";
                } else
                {
                    sqlData = "select * from [Categories] where [Name] like @search and [Deleted_at] is null";
                }

                SqlCommand cmd = new SqlCommand(sqlData, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                if(filterStatus != null)
                {
                    cmd.Parameters.AddWithValue("@Status", filterStatus ?? DBNull.Value.ToString());
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CategoryDetail category = new CategoryDetail();
                        category.Id = Convert.ToInt32(reader["Id"]);
                        category.Name = reader["Name"].ToString();
                        category.Description = reader["Description"].ToString();
                        category.PosterName = reader["Poster"].ToString();
                        category.ParentId = Convert.ToInt32(reader["ParentId"]);
                        category.Status = reader["Status"].ToString();
                        category.Created_at = Convert.ToDateTime(reader["Created_at"]);
                        //categories.Updated_at = reader["Updated_at"] != null ? Convert.ToDateTime(reader["Updated_at"]) : null;
                        //categories.Deleted_at = reader["Deleted_at"] != null ? Convert.ToDateTime(reader["Deleted_at"]) : null;
                        categories.Add(category);
                    }
                }

                conn.Close();
            }
            return categories;
        }

        public bool DeleteCategory(int id = -1)
        {
            bool result = false;
            using (SqlConnection conn = Database.ConnectionDB())
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("DELETE FROM [Categories] WHERE Id = @Id", conn);
                //cmd.Parameters.AddWithValue("@Id", id);
                //result = cmd.ExecuteNonQuery() > 0;
                SqlCommand cmd = new SqlCommand("UPDATE [Categories] SET [Deleted_at] = @Deleted_at WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Deleted_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                result = cmd.ExecuteNonQuery() > 0;
                conn.Close();
            }
            return result;
        }

        public CategoryDetail GetCategoryById(int Id = 0)
        {
            CategoryDetail categoryDetail = new CategoryDetail();

            using (SqlConnection conn = Database.ConnectionDB())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from [Categories] where [Id] = @Id and [Deleted_at] is null", conn);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryDetail.Id = Convert.ToInt32(reader["Id"]);
                            categoryDetail.Name = reader["Name"].ToString();
                            categoryDetail.Description = reader["Description"].ToString();
                            categoryDetail.PosterName = reader["Poster"].ToString();
                            categoryDetail.Status = reader["Status"].ToString();
                        }
                    }
                    conn.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in GetCategoryById: (CategoryQuery)", e.Message);
                }
            }

            return categoryDetail;
        }

        public bool UpdateCategoryById (CategoryDetail category)
        {
            bool result = false;
            using (SqlConnection conn = Database.ConnectionDB())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Categories] SET [Name] = @Name, [Description] = @Description, [Poster] = @Poster, [Status] = @Status, [Updated_at] = @Update_at WHERE [Id] = @Id and [Deleted_at] is null", conn);
                cmd.Parameters.AddWithValue("@Id", category.Id);
                cmd.Parameters.AddWithValue("@Name", category.Name ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Description", category.Description ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Poster", category.PosterName ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Status", category.Status ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Update_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                result = cmd.ExecuteNonQuery() > 0;
                conn.Close();
            }
            return result;
        }   
    }
}
