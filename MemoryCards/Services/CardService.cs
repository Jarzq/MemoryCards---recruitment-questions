using MemoryCards.Models;
using System;
using System.Collections.Generic;

namespace MemoryCards.Services
{
    public interface ICardService
    {
        public CardModel Mainy(List<CardModel> cards);
    }
    public class CardService : ICardService
    {
        List<CardModel> onlyNotKnown = new List<CardModel>();
        private CardModel chosen;
        Random rnd = new Random();
        public CardModel Mainy(List<CardModel> cards)
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
    }
}
