using Microsoft.EntityFrameworkCore;

namespace TEST1.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TestMessage> TestMessages { get; set; }
    }

}
