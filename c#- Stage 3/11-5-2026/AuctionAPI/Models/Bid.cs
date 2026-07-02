namespace AuctionAPI.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int AdvertisementId {  get; set; }
        public double OfferPrice {  get; set; }
        public DateTime OfferDate { get; set; }= DateTime.Now;
        
    }
}
