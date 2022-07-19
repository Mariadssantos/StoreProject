namespace storeproject.Models
{
    public class RequestItem
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public double ValueUnitary { get; set; }
        public double ? Amout { get; set; }
        public string Status { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
