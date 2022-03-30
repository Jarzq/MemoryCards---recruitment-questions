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
        
        List<CardModel> shuffledList = new List<CardModel>();
        List<CardModel> tempList = new List<CardModel>();
        List<CardModel> withoutKnown = new List<CardModel>();
        private CardModel chosen;
        Random rnd = new Random();
        public CardModel Mainy(IQueryable<CardModel> cards)
        {
            tempList = cards.ToList();
            if (tempList.Count != 0)
            {
                chosen = tempList[rnd.Next(0, tempList.Count)];
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
                    withoutKnown.Add(item);
                }
            }

            //Shuffle templist
            if (withoutKnown.Count >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    chosen = withoutKnown[rnd.Next(0, withoutKnown.Count)];

                    shuffledList.Add(chosen);
                    withoutKnown.Remove(chosen);

                }
            }
            //if there are less than 5 items just return original list
            else
            {
               return withoutKnown;
            }
            
            //var newCards = shuffledList.AsQueryable();           
            return shuffledList;
        }
    }
}
