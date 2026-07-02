using System.Text.Json.Serialization;

namespace AuctionAPI.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string ProductName {  get; set; }
        public double BasePrice {  get; set; }
        public string Description {  get; set; }
        public string ItemImage {  get; set; }
        public DateTime CreateDate {  get; set; } = DateTime.Now;
        
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
