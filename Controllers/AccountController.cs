using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using storeproject.Data;
using storeproject.Helpers;
using storeproject.Models;

namespace storeproject.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly dbContext _context;
        public AccountController(dbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/auth")]
        public async Task<IActionResult> Auth([FromBody] Users users)
        {
            try
            {

                var userExists = _context.User.Where(x => x.Username.Contains(users.Username)).FirstOrDefault();

                if (userExists == null)
                    return BadRequest(new { Message = "Username e/ou senha está(ão) inválido(s)." });

                var matchPassword = _context.User.Where(x => x.Password.Contains(users.Password));

                if (matchPassword == null)
                {
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });
                }

                var token = JwtAuth.GenerateToken(userExists);

                return Ok(new
                {
                    Token = token,
                    Usuario = userExists
                });

            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }
}
