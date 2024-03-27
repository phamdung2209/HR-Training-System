using Microsoft.EntityFrameworkCore;

namespace TrainingFPT.DataDBContext
{
    public class TrainingDBContext : DbContext
    {
        //public TrainingDBContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{
        //}

        //public DbSet<Category> Categories { get; set; }

        public TrainingDBContext(DbContextOptions<TrainingDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}

