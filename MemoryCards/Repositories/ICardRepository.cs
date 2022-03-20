using MemoryCards.Models;
using System.Linq;

namespace MemoryCards.Repositories
{
    public interface ICardRepository
    {
        CardModel Get(int id);

        IQueryable<CardModel> GetAll();

        void Add(CardModel card);

        void Update(int id, CardModel model);

        void Delete(int id);
    }
}
