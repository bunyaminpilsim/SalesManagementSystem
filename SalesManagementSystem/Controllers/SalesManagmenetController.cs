using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories;

namespace SalesManagementSystem.Controllers
{
    public class SalesManagmenetController : Controller
    {
        private readonly IOfferRepository _offerRepository;

        public SalesManagmenetController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [HttpGet]
        public IActionResult AddOffer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOffer(Offer offer)
        {
            if (ModelState.IsValid)
            {
                _offerRepository.AddOffer(offer);
                return RedirectToAction("OfferList");
            }
            return View(offer);
        }

        public IActionResult OfferList()
        {
            var offers = _offerRepository.GetAllOffers();
            return View(offers);
        }

        [HttpGet]
        public IActionResult UpdateOffer(int id)
        {
            var offer = _offerRepository.GetOfferByOfferId(id);
            if (offer == null)
            {
                return NotFound();
            }
            return View(offer);
        }

        [HttpPost]
        public IActionResult UpdateOffer(Offer offer)
        {
            if (ModelState.IsValid)
            {
                _offerRepository.UpdateOffer(offer);
                return RedirectToAction("OfferList");
            }
            return View(offer);
        }

        [HttpGet]
        public IActionResult DeleteOffer(int id)
        {

            var offer = _offerRepository.GetOfferByOfferId(id);
            if (offer == null)
            {
                return NotFound();
            }
            _offerRepository.DeleteOffer(offer);
            return RedirectToAction("OfferList");
        }
    }
}
