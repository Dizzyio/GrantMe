using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grant_Me.Data;
using Grant_Me.Models;

namespace Grant_Me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrantsController : ControllerBase
    {
        private readonly GrantDbContext _context;

        public GrantsController(GrantDbContext context)
        {
            _context = context;
        }

        // GET: api/Grants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grant>>> GetGrants()
        {
            return await _context.Grants.ToListAsync();
        }

        // GET: api/Grants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grant>> GetGrant(int id)
        {
            var grant = await _context.Grants.FindAsync(id);
            if (grant == null) return NotFound();
            return grant;
        }

        // POST: api/Grants
        [HttpPost]
        public async Task<ActionResult<Grant>> PostGrant(Grant grant)
        {
            _context.Grants.Add(grant);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGrant), new { id = grant.Id }, grant);
        }

        // PUT: api/Grants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrant(int id, Grant grant)
        {
            if (id != grant.Id) return BadRequest();

            _context.Entry(grant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Grants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrant(int id)
        {
            var grant = await _context.Grants.FindAsync(id);
            if (grant == null) return NotFound();

            _context.Grants.Remove(grant);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
