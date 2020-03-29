using Microsoft.EntityFrameworkCore;

namespace NOWA.Models
{
    public class NOWAContext : DbContext
    {

        public NOWAContext(DbContextOptions options)
        : base(options)
        {}

        public DbSet<Nowa> Nowa { get; set; }

        public DbSet<User> User { get; set; }
    }
}