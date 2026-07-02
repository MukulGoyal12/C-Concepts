namespace AuctionAPI.Models
{
    public class AdvertisementDTO
    {
         
        public string ProductName { get; set; }
        public double BasePrice { get; set; }
        public string Description { get; set; }
        public string ItemImage { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
