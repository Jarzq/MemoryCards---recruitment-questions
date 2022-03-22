using MemoryCards.Models;
using System.Collections.Generic;
using System.Linq;

namespace MemoryCards.Repositories
{
    public interface ICardTempRepository
    {
        CardModel Get(int id);
        CardModel Details(int id);

        IQueryable<CardModel> GetAll();

        void Add(CardModel card);
        void Know(int id);

        void Update(int id, CardModel model);

        void Delete(int id);
        public void Convert(List<CardModel> cards);
    }
}
