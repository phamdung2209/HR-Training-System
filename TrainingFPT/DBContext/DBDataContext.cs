using Microsoft.EntityFrameworkCore;

namespace TrainingFPT.DBContext
{
    public class DBDataContext : DbContext
    {
        public DBDataContext(DbContextOptions<DBDataContext> options) : base(options)
        {
             
        }

        public DbSet<RoleDBContext> Roles { get; set; }

        public DbSet<CategoryDBContext> Categories { get; set; }

        public DbSet<CoursesDBContext> Courses { get; set; }

        public DbSet<UserDBContext> Users { get; set; }
    }
}
