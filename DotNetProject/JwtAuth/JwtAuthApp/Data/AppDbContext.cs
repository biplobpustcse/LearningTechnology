using JwtAuthApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
