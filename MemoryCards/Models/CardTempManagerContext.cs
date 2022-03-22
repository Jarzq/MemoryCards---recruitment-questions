using Microsoft.EntityFrameworkCore;

namespace MemoryCards.Models
{
    public class CardTempManagerContext : DbContext
    {
        public CardTempManagerContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<CardModel> CardsTemp { get; set; }
    }
}
