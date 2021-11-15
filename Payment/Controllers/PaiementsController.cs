using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment.Context;
using Payment.Models;

namespace Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaiementsController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public PaiementsController(PaymentDbContext context)
        {
            _context = context;
        }

        // GET: api/Paiements
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Paiement>>> Getpaiement()
        {
            //string id = HttpContext.User.FindFirstValue("id");
            //string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            //string username = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            return await _context.paiement.ToListAsync();
        }

        // GET: api/Paiements/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Paiement>> GetPaiement(int id)
        {
            var paiement = await _context.paiement.FindAsync(id);

            if (paiement == null)
            {
                return NotFound();
            }

            return paiement;
        }

        // PUT: api/Paiements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPaiement(int id, Paiement paiement)
        {
            if (id != paiement.Id)
            {
                return BadRequest();
            }

            _context.Entry(paiement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiementExists(id))
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

        // POST: api/Paiements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Paiement>> PostPaiement(Paiement paiement)
        {
            _context.paiement.Add(paiement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaiement", new { id = paiement.Id }, paiement);
        }

        // DELETE: api/Paiements/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePaiement(int id)
        {
            var paiement = await _context.paiement.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }

            _context.paiement.Remove(paiement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaiementExists(int id)
        {
            return _context.paiement.Any(e => e.Id == id);
        }
    }
}
