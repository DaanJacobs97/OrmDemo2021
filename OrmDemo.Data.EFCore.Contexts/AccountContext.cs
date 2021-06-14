using Microsoft.EntityFrameworkCore;
using OrmDemo.Data.EFCore.Entities;

namespace OrmDemo.Data.EFCore.Contexts
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=ormefcore;Username=postgres;Password=demoserver");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(254);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(254);
                entity.Property(e => e.LastName)
                    .HasMaxLength(254);
                entity.Property(e => e.Email)
                    .HasMaxLength(254);
            });
        }
    }
}
