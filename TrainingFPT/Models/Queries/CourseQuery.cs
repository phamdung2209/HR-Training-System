using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TrainingFPT.DataDBContext;

namespace TrainingFPT.Models.Queries
{
    public class CourseQuery
    {
        public bool DeleteCourseById(int Id)
        {
            bool checkDelete = false;
            using (SqlConnection conn = Database.ConnectionDB())
            {
                string sql = "update [Courses] set [Deleted_at] = @Deleted_at where [Id] = @Id";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Deleted_at", DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                checkDelete = true;
                conn.Close();
            }
            return checkDelete;
        }

        public List<CourseDetail> GetCourses()
        {
            List<CourseDetail> courses = new List<CourseDetail>();
            using (SqlConnection conn = Database.ConnectionDB())
            {
                conn.Open();

                string sql = "SELECT [co].*, [ca].[Name] AS [CategoryName] FROM [Courses] AS [co] INNER JOIN [Categories] AS [ca] ON [co].[CategoryId] = [ca].[Id] WHERE [co].[Deleted_At] IS NULL ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CourseDetail course = new CourseDetail();
                        course.Id = Convert.ToInt32(reader["Id"]);
                        course.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                        course.Name = reader["Name"].ToString()!;
                        course.Description = reader["Description"].ToString();
                        course.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        course.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        course.Status = reader["Status"].ToString()!;
                        course.ImageUrlString = reader["ImageUrl"].ToString();
                        course.CategoryName = reader["CategoryName"].ToString();
                        courses.Add(course);

                    }
                }

                conn.Close();
            }
            return courses;
        }

        public int AddCourse(string name, int categoryId, string? description, string imageUrl, DateTime? startDate, DateTime? endDate, string status)
        {
            int idCourse = 0;

            using (SqlConnection conn = Database.ConnectionDB())
            {
                conn.Open();

                string sql = "INSERT INTO[Courses]([CategoryId], [Name], [Description], [ImageUrl], [StartDate], [EndDate], [Status], [Created_at]) VALUES(@CategoryId, @Name, @Description, @ImageUrl, @StartDate, @EndDate, @Status, @Created_at) SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                idCourse = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            return idCourse;
        }

        // edit course
        public CourseDetail GetCourseById(int Id = 0)
        {
            CourseDetail course = new CourseDetail();
            using (SqlConnection conn = Database.ConnectionDB())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Courses] WHERE [Id] = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        course.Id = Convert.ToInt32(reader["Id"]);
                        course.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                        course.Name = reader["Name"].ToString()!;
                        course.Description = reader["Description"].ToString();
                        course.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        course.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        course.Status = reader["Status"].ToString()!;
                        course.ImageUrlString = reader["ImageUrl"].ToString();
                    }
                }
                conn.Close();
            }
            return course;
        }
    }
}
