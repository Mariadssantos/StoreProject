using storeproject.Data;
using storeproject.Models;

namespace storeproject.Services
{
    public class UsersServices
    {
        private readonly dbContext _context;
        public UsersServices(dbContext context)
        {
            _context = context;
        }
        public async Task<bool> validateUser(Users users)
        {
            var result = _context.User.Where(x => x.Username.Contains(users.Username));
            if (result.Any())
                return false;
            return true;
        }
    }
}
