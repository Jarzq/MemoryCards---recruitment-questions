using MemoryCards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MemoryCards.Services;

namespace MemoryCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardService _service;
        public CardsController(ICardService service)
        {
            _service = service;
        }
        private static List<CardModel> cards = new List<CardModel>()
        {
            new CardModel() { Id = 1, Question ="Roznica miedzy int a int 32", Answer="brak roznicy",IsKnown=false, level=1},
            new CardModel() { Id = 2, Question ="drugie pytanie", Answer="brak roznicy",IsKnown=false, level=1},
            new CardModel() { Id = 3, Question ="trzecie pytanie", Answer="brak roznicy",IsKnown=false, level=1},
            new CardModel() { Id = 4, Question ="czwarte pytanie", Answer="brak roznicy",IsKnown=false, level=1},
            new CardModel() { Id = 5, Question ="piate pytanie", Answer="brak roznicy",IsKnown=false, level=1}
        };
        
        // GET: CardsController
        public ActionResult Mainy()
        {
            var chosenCard = _service.Mainy(cards);
            if(chosenCard == null)
            {
                return View("Gratulation");
            }
            else
            {
                return View(chosenCard);
            }
            
        }
        public ActionResult Index()
        {
            return View(cards);
        }

        // GET: CardsController/Details/5
        public ActionResult Details(int id)
        {
            return View(cards.FirstOrDefault(x => x.Id == id));
        }

        // GET: CardsController/Create
        public ActionResult Create()
        {
            return View(new CardModel());
        }

        // POST: CardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardModel cardModel)
        {
                cardModel.Id = cards.Count + 1;
                cards.Add(cardModel);
                return RedirectToAction(nameof(Index));         
        }

        // GET: CardsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(cards.FirstOrDefault(x => x.Id == id));
            
        }

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardModel cardModel)
        {
                CardModel card = cards.FirstOrDefault(x => x.Id == id);
                card.Id = id;
                card.Question = cardModel.Question;
                card.Answer = cardModel.Answer;
                card.level = cardModel.level;
                return RedirectToAction(nameof(Index));   
                
        }

        // GET: CardsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cards.FirstOrDefault(x => x.Id == id));
        }

        // POST: CardsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CardModel cardModel)
        {
            var card = cards.FirstOrDefault(x => x.Id == id);
            cards.Remove(card);
            return RedirectToAction(nameof(Index));       
        }
        [HttpPost]
        public ActionResult Know(int id)
        {
            var result = cards.FirstOrDefault(x => x.Id == id);
            result.IsKnown = true;
            result.level++;

            return RedirectToAction(nameof(Mainy));
        }
    }
}
