using Microsoft.EntityFrameworkCore;

namespace MemoryCards.Models
{
    public class CardManagerContext : DbContext
    {
        public CardManagerContext(DbContextOptions<CardManagerContext> options) : base(options)
        {
        }
        public DbSet<CardModel> Cards { get; set; }
    }
}
