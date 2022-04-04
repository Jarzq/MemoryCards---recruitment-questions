using MemoryCards.Models;
using System.Linq;

namespace MemoryCards.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CardManagerContext _context;
        public CardRepository(CardManagerContext context )
        {
            _context = context;
        }
        public void Add(CardModel card)
        {
            card.FirstAttemp = true;
            if(card is null)
            {
               
            }
            else
            {
                _context.Cards.Add(card);
                _context.SaveChanges();
            }
           
        }
            
        
        public CardModel Get(int id)
           => _context.Cards.SingleOrDefault(card => card.Id == id);
        

        public void Update(int id, CardModel model)
        {
            var result = _context.Cards.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Question = model.Question;
                result.Answer = model.Answer;

                _context.SaveChanges();
            }
           
        }

        public void Delete(int id)
        {
            var result = _context.Cards.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.Cards.Remove(result);
                _context.SaveChanges();
            }
        }

        public IQueryable<CardModel> GetAll()
            => _context.Cards;

        public CardModel Details(int id)
        {
            var result = _context.Cards.SingleOrDefault(x => x.Id == id);
            return result;
        }

        public void Know(int id)
        {
            var result = _context.Cards.SingleOrDefault(x => x.Id == id);

            if(result.FirstAttemp==true)
            {
                result.level++;
            }
            result.FirstAttemp = true;

            if (result.level>3)
                result.IsKnown=true;

            _context.SaveChanges();
        }

        public void DontKnow(int id)
        {
            var result = _context.Cards.SingleOrDefault(x => x.Id == id);
            result.FirstAttemp = false;
            _context.SaveChanges();
        }
    }
}
