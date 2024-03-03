
using Microsoft.EntityFrameworkCore;
using publishers.Domain.Entities;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Context
{
    public class PubsContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasKey(s => s.stor_id); 
        }

        public PubsContext(DbContextOptions<PubsContext> options) : base(options) { }
        public DbSet<Store> stores { get; set; }
    }
}
