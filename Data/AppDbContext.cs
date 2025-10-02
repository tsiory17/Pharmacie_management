using Microsoft.EntityFrameworkCore;
using Pharmacie_management.Models;

namespace Pharmacie_management.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(index => index.Name)
            .IsUnique();
        }
    }
}