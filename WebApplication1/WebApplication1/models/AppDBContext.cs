

using Microsoft.EntityFrameworkCore;

namespace WebApplication1.models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Users> users { get; set; }
        public DbSet<Posts> posts { get; set; }
    }
}
