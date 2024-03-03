using publishers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using publishers.Infrastructure.Models;

namespace publishers.Infrastructure.Contex
{
    public class PubsContex : DbContext
    {
        public PubsContex(DbContextOptions<PubsContex> options) : base(options) 
        {

        }

        public DbSet<Jobs> jobs { get; set; }

        public DbSet<roysched> roysched { get; set; }
        public DbSet<TitleModel> titles { get; set; }
    }
}
