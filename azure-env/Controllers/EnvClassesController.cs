using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using azure_env.Models;

namespace azure_env.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvClassesController : ControllerBase
    {
        private readonly EnvContext _context;

        public EnvClassesController(EnvContext context)
        {
            _context = context;
        }

        // GET: api/EnvClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvClass>>> GetEnvItems()
        {
            return await _context.EnvItems.ToListAsync();
        }

        // GET: api/EnvClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvClass>> GetEnvClass(long id)
        {
            var envClass = await _context.EnvItems.FindAsync(id);

            if (envClass == null)
            {
                return NotFound();
            }

            return envClass;
        }

        // PUT: api/EnvClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvClass(long id, EnvClass envClass)
        {
            if (id != envClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(envClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvClassExists(id))
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

        // POST: api/EnvClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnvClass>> PostEnvClass(EnvClass envClass)
        {
            _context.EnvItems.Add(envClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvClass", new { id = envClass.Id }, envClass);
        }

        // DELETE: api/EnvClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvClass(long id)
        {
            var envClass = await _context.EnvItems.FindAsync(id);
            if (envClass == null)
            {
                return NotFound();
            }

            _context.EnvItems.Remove(envClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvClassExists(long id)
        {
            return _context.EnvItems.Any(e => e.Id == id);
        }
    }
}
