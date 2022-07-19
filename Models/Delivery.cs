namespace storeproject.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int IdRequestItem { get; set; }
        public int IdDriver { get; set; }
        public string ? ExpectedDate { get; set; }
        public string Status { get; set; }
        public string Observation { get; set; }
    }
}
