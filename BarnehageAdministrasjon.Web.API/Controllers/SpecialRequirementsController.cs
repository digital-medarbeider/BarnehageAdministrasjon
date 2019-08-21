using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarnehageAdministrasjon.Models;

namespace BarnehageAdministrasjon.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialRequirementsController : ControllerBase
    {
        private readonly KindergartenContext _context;

        public SpecialRequirementsController(KindergartenContext context)
        {
            _context = context;
        }

        // GET: api/SpecialRequirements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialRequirement>>> GetSpecialRequirements()
        {
            return await _context.SpecialRequirements.ToListAsync();
        }

        // GET: api/SpecialRequirements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialRequirement>> GetSpecialRequirement(int id)
        {
            var specialRequirement = await _context.SpecialRequirements.FindAsync(id);

            if (specialRequirement == null)
            {
                return NotFound();
            }

            return specialRequirement;
        }

        // PUT: api/SpecialRequirements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialRequirement(int id, SpecialRequirement specialRequirement)
        {
            if (id != specialRequirement.SpecialRequirementId)
            {
                return BadRequest();
            }

            _context.Entry(specialRequirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialRequirementExists(id))
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

        // POST: api/SpecialRequirements
        [HttpPost]
        public async Task<ActionResult<SpecialRequirement>> PostSpecialRequirement(SpecialRequirement specialRequirement)
        {
            _context.SpecialRequirements.Add(specialRequirement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialRequirement", new { id = specialRequirement.SpecialRequirementId }, specialRequirement);
        }

        // DELETE: api/SpecialRequirements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialRequirement>> DeleteSpecialRequirement(int id)
        {
            var specialRequirement = await _context.SpecialRequirements.FindAsync(id);
            if (specialRequirement == null)
            {
                return NotFound();
            }

            _context.SpecialRequirements.Remove(specialRequirement);
            await _context.SaveChangesAsync();

            return specialRequirement;
        }

        private bool SpecialRequirementExists(int id)
        {
            return _context.SpecialRequirements.Any(e => e.SpecialRequirementId == id);
        }
    }
}
