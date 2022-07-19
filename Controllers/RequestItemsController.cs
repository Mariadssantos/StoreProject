using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeproject.Data;
using storeproject.Models;
using storeproject.Services;

namespace storeproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestItemsController : ControllerBase
    {
        private readonly dbContext _context;
        public RequestItemServices _requestItemServices;

        public RequestItemsController(dbContext context, RequestItemServices requestItemServices)
        {
            _context = context;
            _requestItemServices = requestItemServices;
        }

        // GET: api/RequestItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestItem>>> GetRequestItem()
        {
          if (_context.RequestItem == null)
          {
              return NotFound();
          }
            return await _context.RequestItem.Include(x => x.Product).ToListAsync();
        }

        // GET: api/RequestItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestItem>> GetRequestItem(int id)
        {
          if (_context.RequestItem == null)
          {
              return NotFound();
          }
            var requestItem = await _context.RequestItem.FindAsync(id);

            if (requestItem == null)
            {
                return NotFound();
            }

            return requestItem;
        }

        // PUT: api/RequestItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestItem(int id, RequestItem requestItem)
        {
            if (id != requestItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestItemExists(id))
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

        // POST: api/RequestItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestItem>> PostRequestItem([FromBody] RequestItem requestItem)
        {

            var amout = await _requestItemServices.calculateAmout(requestItem);
            requestItem.Amout = amout;
            if (_context.RequestItem == null)
          {
              return Problem("Entity set 'dbContext.RequestItem'  is null.");
          }
            _context.RequestItem.Add(requestItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestItem", new { id = requestItem.Id }, requestItem);
        }

        // DELETE: api/RequestItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestItem(int id)
        {
            if (_context.RequestItem == null)
            {
                return NotFound();
            }
            var requestItem = await _context.RequestItem.FindAsync(id);
            if (requestItem == null)
            {
                return NotFound();
            }

            _context.RequestItem.Remove(requestItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestItemExists(int id)
        {
            return (_context.RequestItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
