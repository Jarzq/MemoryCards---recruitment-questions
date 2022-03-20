using MemoryCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryCards.Services
{
    public interface ICardService
    {
        public CardModel Mainy(IQueryable<CardModel> cards);
        public List<CardModel> ShuffleTen(List<CardModel> cards);
    }
    public class CardService : ICardService
    {
        List<CardModel> onlyNotKnown = new List<CardModel>();
        List<CardModel> shuffledList = new List<CardModel>();
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

        public List<CardModel> ShuffleTen(List<CardModel> cards)
        {
            for (int i = 0; i < 5; i++)
            {
                chosen = cards[rnd.Next(0, cards.Count)];
                shuffledList.Add(chosen);
            }
            return shuffledList;
        }
    }
}
