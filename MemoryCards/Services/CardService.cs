using MemoryCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryCards.Services
{
    public interface ICardService
    {
        public CardModel Mainy(IQueryable<CardModel> cards);
        public List<CardModel> ShuffleTen(IQueryable<CardModel> cards);
    }
    public class CardService : ICardService
    {
        List<CardModel> onlyNotKnown = new List<CardModel>();
        List<CardModel> shuffledList = new List<CardModel>();
        List<CardModel> tempList = new List<CardModel>();
        private CardModel chosen;
        Random rnd = new Random();
        public CardModel Mainy(IQueryable<CardModel> cards)
        {
            foreach(CardModel item in cards)
            {
                if (!item.IsKnown) { onlyNotKnown.Add(item); }
            }
            if(onlyNotKnown.Count != 0)
            {
                chosen = onlyNotKnown[rnd.Next(0, onlyNotKnown.Count)];
            }

            return chosen;
        }

        public List<CardModel> ShuffleTen(IQueryable<CardModel> cards)
        {

            tempList = cards.ToList();                          

            for (int i = 0; i < 5; i++)
            {
                chosen = tempList[rnd.Next(0, tempList.Count)];
                shuffledList.Add(chosen);
                tempList.Remove(chosen);
            }

            //var newCards = shuffledList.AsQueryable();
            
            return shuffledList;
        }
    }
}
