using Microsoft.EntityFrameworkCore;

namespace TrainingFPT.DataDBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
