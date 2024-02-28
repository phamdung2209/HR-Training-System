using Microsoft.EntityFrameworkCore;
using TrainingFPT.DBContext;

namespace TrainingFPT.DataDBContext
{
    public class TrainingDBContext : DbContext
    {
        public TrainingDBContext(DbContextOptions<TrainingDBContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
