using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpBackEnd.Domain;
using Microsoft.EntityFrameworkCore;

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishingCompanyController : Controller
    {
        private readonly ApiContext _context;

        public PublishingCompanyController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublishingCompany>>> GetPublishingCompany()
        {
            return await _context.PublishingCompanies.ToListAsync();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<PublishingCompany>> GetPublishingCompany(int id)
        {
            var company = await _context.PublishingCompanies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishingCompany(int id, PublishingCompany company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishingCompanyExists(id))
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
        public async Task<ActionResult<PublishingCompany>> PostPublishingCompany(PublishingCompany company)
        {
            _context.PublishingCompanies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublishingCompany", new { id = company.Id }, company);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PublishingCompany>> DeletePublishingCompany(int id)
        {
            var company = await _context.PublishingCompanies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.PublishingCompanies.Remove(company);
            await _context.SaveChangesAsync();

            return company;
        }

        private bool PublishingCompanyExists(int id)
        {
            return _context.PublishingCompanies.Any(e => e.Id == id);
        }
    }
}