using Microsoft.EntityFrameworkCore;
using storeproject.Models;

namespace storeproject.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        { }
        public DbSet<Users>? User { get; set; }
        public DbSet<Driver>? Driver { get; set; }
    }
}
