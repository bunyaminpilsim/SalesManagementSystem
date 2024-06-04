using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        List<SelectListItem> categories = new List<SelectListItem>()
        {
            new SelectListItem {Value="Teklif",Text="Teklif"},
            new SelectListItem {Value="Pazarlık",Text="Pazarlık"},
            new SelectListItem {Value="Kazanıldı",Text="Kazanıldı"},
            new SelectListItem {Value="Kaybedildi",Text="Kaybedildi"},
        };

        [HttpGet]
        public IActionResult AddOffer()
        {
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult AddOffer(Offer offer)
        {
            if (ModelState.IsValid)
            {
                _offerRepository.AddOffer(offer);
                ViewBag.Categories = categories;
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
            ViewBag.Categories = categories;
            return View(offer);
        }

        [HttpPost]
        public IActionResult UpdateOffer(Offer offer)
        {
            if (ModelState.IsValid)
            {
                _offerRepository.UpdateOffer(offer);
                ViewBag.Categories = categories;
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
