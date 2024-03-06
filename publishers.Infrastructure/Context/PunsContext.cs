using Microsoft.EntityFrameworkCore;
using publishers.Domain.Entities;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Context
{
    public class PubsContext: DbContext
    {
        public PubsContext (DbContextOptions<PubsContext> options) : base(options) { }

        public DbSet<Discounts> discounts { get; set; }
        public DbSet<StoresModel> stores { get; set; }

    }
}
