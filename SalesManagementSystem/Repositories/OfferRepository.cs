using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private List<Offer> _offers = new List<Offer>()
        {
            new Offer {Id=1,OfferName="Akademi",CustomerName="Acun Medya",OfferAmount=35000,Category="Teklif" }
        };

        public void AddOffer(Offer offer)
        {
            _offers.Add(offer);
        }

        public List<Offer> GetAllOffers()
        {
            return _offers;
        }

        public Offer GetOfferByOfferId(int id)
        {
            foreach (var offer in _offers)
            {

                if (offer.Id == id)
                {
                    return offer;
                }
            }
            return null;
        }

        public void UpdateOffer(Offer offer)
        {
            var existingOffer = GetOfferByOfferId(offer.Id);
            if (existingOffer != null)
            {
                existingOffer.OfferName = offer.OfferName;
                existingOffer.CustomerName = offer.CustomerName;
                existingOffer.OfferAmount = offer.OfferAmount;
                existingOffer.Category = offer.Category;
                
            }
        }

        public void DeleteOffer(Offer offer)
        {
            _offers.Remove(offer);
        }
    }
}
