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


        // GET: api/PublishingCompany/5
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

        // PUT: api/PublishingCompany/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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

        // POST: api/PublishingCompany
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PublishingCompany>> PostPublishingCompany(PublishingCompany company)
        {
            _context.PublishingCompanies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublishingCompany", new { id = company.Id }, company);
        }

        // DELETE: api/PublishingCompany/5
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