namespace storeproject.Models
{
    public class ClientAdress
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string PublicPlace { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string CEP { get; set; }
    }
}
