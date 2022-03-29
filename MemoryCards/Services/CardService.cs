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

            //Removing from tempList all known items
            foreach (var item in tempList)
            {
                if (item.IsKnown == false)
                {
                    tempList.Remove(chosen);
                }
            }

            //Shuffle templist
            if (tempList.Count >= 5)
            {
                for (int i = 0; i < 5; i++)
                {

                    chosen = tempList[rnd.Next(0, tempList.Count)];

                    shuffledList.Add(chosen);
                    tempList.Remove(chosen);

                }
            }
            //if there are less than 5 items just return original list
            else
            {
               return tempList;
            }
            

            //var newCards = shuffledList.AsQueryable();
            
            return shuffledList;
        }
    }
}
