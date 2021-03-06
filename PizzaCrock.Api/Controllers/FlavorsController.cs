﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Infra;

namespace PizzaCrock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlavorsController : ControllerBase
    {
        private readonly PizzaCrockDbContext _context;

        public FlavorsController(PizzaCrockDbContext context)
        {
            _context = context;
        }

        // GET: api/Flavors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flavor>>> GetFlavors()
        {
            return await _context.Flavors.ToListAsync();
        }

        // GET: api/Flavors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flavor>> GetFlavor(int id)
        {
            var flavor = await _context.Flavors.FindAsync(id);

            if (flavor == null)
            {
                return NotFound();
            }

            return flavor;
        }

        // PUT: api/Flavors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlavor(int id, Flavor flavor)
        {
            if (id != flavor.Id)
            {
                return BadRequest();
            }

            _context.Entry(flavor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlavorExists(id))
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

        // POST: api/Flavors
        [HttpPost]
        public async Task<ActionResult<Flavor>> PostFlavor(Flavor flavor)
        {
            _context.Flavors.Add(flavor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlavor", new { id = flavor.Id }, flavor);
        }

        // DELETE: api/Flavors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flavor>> DeleteFlavor(int id)
        {
            var flavor = await _context.Flavors.FindAsync(id);
            if (flavor == null)
            {
                return NotFound();
            }

            _context.Flavors.Remove(flavor);
            await _context.SaveChangesAsync();

            return flavor;
        }

        private bool FlavorExists(int id)
        {
            return _context.Flavors.Any(e => e.Id == id);
        }
    }
}
