
using Microsoft.EntityFrameworkCore;
using publishers.Domain.Entities;

namespace publishers.Infrastructure.Context
{
    public class PubsContext : DbContext
    {
        public PubsContext(DbContextOptions<PubsContext> options) : base(options) { }

        public DbSet<Titles> titles { get; set; }
    }
}
