using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeproject.Data;
using storeproject.Models;

namespace storeproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAdressesController : ControllerBase
    {
        private readonly dbContext _context;

        public ClientAdressesController(dbContext context)
        {
            _context = context;
        }

        // GET: api/ClientAdresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientAdress>>> GetClientAdress()
        {
          if (_context.ClientAdress == null)
          {
              return NotFound();
          }
            return await _context.ClientAdress.ToListAsync();
        }

        // GET: api/ClientAdresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientAdress>> GetClientAdress(int id)
        {
          if (_context.ClientAdress == null)
          {
              return NotFound();
          }
            var clientAdress = await _context.ClientAdress.FindAsync(id);

            if (clientAdress == null)
            {
                return NotFound();
            }

            return clientAdress;
        }

        // PUT: api/ClientAdresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientAdress(int id, ClientAdress clientAdress)
        {
            if (id != clientAdress.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientAdress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientAdressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClientAdresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientAdress>> PostClientAdress(ClientAdress clientAdress)
        {
          if (_context.ClientAdress == null)
          {
              return Problem("Entity set 'dbContext.ClientAdress'  is null.");
          }
            _context.ClientAdress.Add(clientAdress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientAdress", new { id = clientAdress.Id }, clientAdress);
        }

        // DELETE: api/ClientAdresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientAdress(int id)
        {
            if (_context.ClientAdress == null)
            {
                return NotFound();
            }
            var clientAdress = await _context.ClientAdress.FindAsync(id);
            if (clientAdress == null)
            {
                return NotFound();
            }

            _context.ClientAdress.Remove(clientAdress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientAdressExists(int id)
        {
            return (_context.ClientAdress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
