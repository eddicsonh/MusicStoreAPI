using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;

namespace MusicStore.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }

        //Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasKey(x => x.Id);
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Genre>().Property(x => x.Status);
        }

        //Entities to table

        public DbSet<Genre> Genres { get; set; }
    }
}
