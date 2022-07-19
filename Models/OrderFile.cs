namespace storeproject.Models
{
    public class OrderFile
    {
        public int Id { get; set; }
        public string CodeRequest { get; set; }
        public string? DateRequest { get; set; }
        public int IdClient { get; set; }
        public int IdRequestItem { get; set; }
        public string ? DeliveryDate { get; set; }
        public string PaymentOption { get; set; }
        public string Status { get; set; }
        
    }
}
