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
    public class OrderFilesController : ControllerBase
    {
        private readonly dbContext _context;

        public OrderFilesController(dbContext context)
        {
            _context = context;
        }

        // GET: api/OrderFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderFile>>> GetOrderFile()
        {
          if (_context.OrderFile == null)
          {
              return NotFound();
          }
            return await _context.OrderFile.ToListAsync();
        }

        // GET: api/OrderFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderFile>> GetOrderFile(int id)
        {
          if (_context.OrderFile == null)
          {
              return NotFound();
          }
            var orderFile = await _context.OrderFile.FindAsync(id);

            if (orderFile == null)
            {
                return NotFound();
            }

            return orderFile;
        }

        // PUT: api/OrderFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderFile(int id, OrderFile orderFile)
        {
            if (id != orderFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderFileExists(id))
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

        // POST: api/OrderFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderFile>> PostOrderFile(OrderFile orderFile)
        {
          if (_context.OrderFile == null)
          {
              return Problem("Entity set 'dbContext.OrderFile'  is null.");
          }
            _context.OrderFile.Add(orderFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderFile", new { id = orderFile.Id }, orderFile);
        }

        // DELETE: api/OrderFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderFile(int id)
        {
            if (_context.OrderFile == null)
            {
                return NotFound();
            }
            var orderFile = await _context.OrderFile.FindAsync(id);
            if (orderFile == null)
            {
                return NotFound();
            }

            _context.OrderFile.Remove(orderFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderFileExists(int id)
        {
            return (_context.OrderFile?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
