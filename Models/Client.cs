namespace storeproject.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public bool Status { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
