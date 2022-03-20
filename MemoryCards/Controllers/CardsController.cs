using MemoryCards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MemoryCards.Services;
using MemoryCards.Repositories;

namespace MemoryCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICardService _service;
        public CardsController(ICardService service, ICardRepository cardRepository)
        {
            _service = service;
            _cardRepository = cardRepository;
        }
        
        

        // GET: CardsController
        public ActionResult Mainy()
        {
            var chosenCard = _service.Mainy(_cardRepository.GetAll());
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
            return View(_cardRepository.GetAll());
        }

        // GET: CardsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_cardRepository.Details(id));
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
                
                _cardRepository.Add(cardModel);
                return RedirectToAction(nameof(Index));         
        }

        // GET: CardsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_cardRepository.Get(id));
        }

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardModel cardModel)
        {
            _cardRepository.Update(id, cardModel);
            return RedirectToAction(nameof(Index));   
                
        }

        // GET: CardsController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_cardRepository.Get(id));
        }

        // POST: CardsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CardModel cardModel)
        {
            _cardRepository.Delete(id);
            return RedirectToAction(nameof(Index));       
        }

        [HttpPost]
        public ActionResult Know(int id)
        {
            _cardRepository.Know(id);

            return RedirectToAction(nameof(Mainy));
        }
    }
}
