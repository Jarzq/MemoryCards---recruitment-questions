using MemoryCards.Models;
using System.Collections.Generic;
using System.Linq;

namespace MemoryCards.Repositories
{
    public class CardTempRepository : ICardTempRepository
    {
        private readonly CardTempManagerContext _context;
        public CardTempRepository(CardTempManagerContext context)
        {
            _context = context;
        }

        public void Add(CardModel card)
        {

            _context.CardsTemp.Add(card);
            _context.SaveChanges();
        }

        public void Convert(List<CardModel> cards)
        {
            _context.CardsTemp.RemoveRange(_context.CardsTemp);
            _context.SaveChanges();

            var results = cards.AsQueryable();


            foreach (var result in results)
            {
                _context.CardsTemp.Add(result);
                _context.SaveChanges();
            }
        }



        public CardModel Get(int id)
           => _context.CardsTemp.SingleOrDefault(card => card.Id == id);


        public void Update(int id, CardModel model)
        {
            var result = _context.CardsTemp.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Question = model.Question;
                result.Answer = model.Answer;
                result.level = model.level;

                _context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var result = _context.CardsTemp.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.CardsTemp.Remove(result);
                _context.SaveChanges();
            }
        }

        public IQueryable<CardModel> GetAll()
            => _context.CardsTemp;

        public CardModel Details(int id)
        {
            var result = _context.CardsTemp.SingleOrDefault(x => x.Id == id);
            return result;
        }

        public void Know(int id)
        {
            var result = _context.CardsTemp.SingleOrDefault(x => x.Id == id);
            _context.CardsTemp.Remove(result);
            _context.SaveChanges();
        }


    }
}
