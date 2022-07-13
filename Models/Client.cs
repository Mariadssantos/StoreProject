namespace storeproject.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public bool Status { get; set; }
        public int IdAdress { get; set; }
        public ClientAdress? ClientAdress { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
