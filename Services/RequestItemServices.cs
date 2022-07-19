using storeproject.Data;
using storeproject.Models;

namespace storeproject.Services
{
    public class RequestItemServices
    {
        private readonly dbContext _context;
        public RequestItemServices(dbContext context)
        {
            _context = context;
        }
        public async Task<dynamic> calculateAmout(RequestItem requestItem)
        {
            //int qtd = Int32.Parse(requestItem.Quantity);
           // double vUnit = Double.Parse(requestItem.ValueUnitary);
            var result = requestItem.Quantity * requestItem.ValueUnitary;
            return result;
        }
    }
}
