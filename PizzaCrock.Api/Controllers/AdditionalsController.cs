using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaCrock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalsController : ControllerBase
    {
        private readonly PizzaCrockDbContext _context;

        public AdditionalsController(PizzaCrockDbContext context)
        {
            _context = context;
        }

   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Additional>>> GetAdditionals()
        {
            return await _context.Additionals.ToListAsync();
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<Additional>> GetAdditional(int id)
        {
            var additional = await _context.Additionals.FindAsync(id);

            if (additional == null)
            {
                return NotFound();
            }

            return additional;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditional(int id, Additional additional)
        {
            if (id != additional.Id)
            {
                return BadRequest();
            }

            _context.Entry(additional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalExists(id))
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

     
        [HttpPost]
        public async Task<ActionResult<Additional>> PostAdditional(Additional additional)
        {
            _context.Additionals.Add(additional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditional", new { id = additional.Id }, additional);
        }

      
        [HttpDelete("{id}")]
        public async Task<ActionResult<Additional>> DeleteAdditional(int id)
        {
            var additional = await _context.Additionals.FindAsync(id);
            if (additional == null)
            {
                return NotFound();
            }

            _context.Additionals.Remove(additional);
            await _context.SaveChangesAsync();

            return additional;
        }

        private bool AdditionalExists(int id)
        {
            return _context.Additionals.Any(e => e.Id == id);
        }
    }
}
