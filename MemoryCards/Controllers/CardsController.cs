using MemoryCards.Models;
using MemoryCards.Repositories;
using MemoryCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoryCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardRepository _cardRepository;
        private ICardTempRepository _cardTempRepository;
        private readonly ICardService _service;
        public CardsController(ICardService service, ICardRepository cardRepository, ICardTempRepository cardTempRepository)
        {
            _service = service;
            _cardRepository = cardRepository;
            _cardTempRepository = cardTempRepository;
        }


        public ActionResult Mainy()
        {
            var chosenCard = _service.Mainy(_cardTempRepository.GetAll());
            if (chosenCard == null)
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
            var result = _service.ShuffleTen(_cardRepository.GetAll());
            _cardTempRepository.Convert(result);
            return View(_cardRepository.GetAll());
        }


        public ActionResult Details(int id)
        {
            return View(_cardRepository.Details(id));
        }


        public ActionResult Create()
        {
            return View(new CardModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardModel cardModel)
        {

            _cardRepository.Add(cardModel);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            return View(_cardRepository.Get(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardModel cardModel)
        {
            _cardRepository.Update(id, cardModel);
            return RedirectToAction(nameof(Index));

        }


        public ActionResult Delete(int id)
        {

            return View(_cardRepository.Get(id));
        }


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
            _cardTempRepository.Know(id);
            _cardRepository.Know(id);
            return RedirectToAction(nameof(Mainy));
        }

        [HttpPost]
        public ActionResult DontKnow(int id)
        {
            _cardRepository.DontKnow(id);
            return RedirectToAction(nameof(Mainy));
        }
    }
}
