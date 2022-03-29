using MemoryCards.Models;
using System.Linq;

namespace MemoryCards.Repositories
{
    public interface ICardRepository
    {
        CardModel Get(int id);
        CardModel Details(int id);

        IQueryable<CardModel> GetAll();

        void Add(CardModel card);
        void Know(int id);
        void DontKnow(int id);

        void Update(int id, CardModel model);

        void Delete(int id);
    }
}
