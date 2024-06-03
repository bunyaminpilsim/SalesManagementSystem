using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories
{
    public interface IOfferRepository
    {
        void AddOffer(Offer offer);
        List<Offer> GetAllOffers();
        Offer GetOfferByOfferId(int listingNumber);
        void UpdateOffer(Offer car);
        void DeleteOffer(Offer car);
    }
}
