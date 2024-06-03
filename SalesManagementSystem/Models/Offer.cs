namespace SalesManagementSystem.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public string CustomerName { get; set; }
        public string Category { get; set; }
        public double OfferAmount { get; set; }
    }
}
