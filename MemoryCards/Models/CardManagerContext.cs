using Microsoft.EntityFrameworkCore;

namespace MemoryCards.Models
{
    public class CardManagerContext : DbContext
    {
        public CardManagerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CardModel> Cards { get; set; }
    }
}
