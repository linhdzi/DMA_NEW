using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_GIT.Data;
using CRUD_GIT.Models;

namespace CRUD_GIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardsController : ControllerBase
    {
        private readonly CRUD_GITContext _context;

        public WardsController(CRUD_GITContext context)
        {
            _context = context;
        }

        // GET: api/Wards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ward>>> GetWard()
        {
          if (_context.Ward == null)
          {
              return NotFound();
          }
            return await _context.Ward.ToListAsync();
        }

        // GET: api/Wards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ward>> GetWard(int id)
        {
          if (_context.Ward == null)
          {
              return NotFound();
          }
            var ward = await _context.Ward.FindAsync(id);

            if (ward == null)
            {
                return NotFound();
            }

            return ward;
        }

        // PUT: api/Wards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWard(int id, Ward ward)
        {
            if (id != ward.WardId)
            {
                return BadRequest();
            }

            _context.Entry(ward).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardExists(id))
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

        // POST: api/Wards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ward>> PostWard(Ward ward)
        {
          if (_context.Ward == null)
          {
              return Problem("Entity set 'CRUD_GITContext.Ward'  is null.");
          }
            _context.Ward.Add(ward);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWard", new { id = ward.WardId }, ward);
        }

        // DELETE: api/Wards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWard(int id)
        {
            if (_context.Ward == null)
            {
                return NotFound();
            }
            var ward = await _context.Ward.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }

            _context.Ward.Remove(ward);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WardExists(int id)
        {
            return (_context.Ward?.Any(e => e.WardId == id)).GetValueOrDefault();
        }
    }
}
