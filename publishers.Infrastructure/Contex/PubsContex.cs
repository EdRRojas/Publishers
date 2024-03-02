using publishers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace publishers.Infrastructure.Contex
{
    public class PubsContex : DbContext
    {
        public PubsContex(DbContextOptions<PubsContex> options) : base(options) 
        {

        }

        public DbSet<Jobs> jobs {  get; set; } 
    }
}
