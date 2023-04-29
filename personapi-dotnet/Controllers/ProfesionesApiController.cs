using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/Profesiones")]
    [ApiController]
    public class ProfesionesApiController : Controller
    {

        private readonly ArqPerDbContext _context;

        public ProfesionesApiController(ArqPerDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProfesionesApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesion>>> Get()
        {
            return await _context.Profesions.ToListAsync();
        }

        // GET api/<ProfesionesApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesion>> Get(int id)
        {
            if (id == null || _context.Profesions == null)
            {
                return NotFound();
            }

            var Profesion = await _context.Profesions
                .Include(e => e.Id)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Profesion == null)
            {
                return NotFound();
            }

            return Profesion;
        }

        // POST api/<ProfesionesApiController>
        [HttpPost]
        public async Task<ActionResult<Profesion>> Post(Profesion profesion)
        {

            _context.Add(profesion);
            await _context.SaveChangesAsync();


            return profesion;
        }

        // PUT api/<ProfesionesApiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Profesion>> Put(int id, Profesion profesion)
        {
            if (id == null || _context.Profesions == null)
            {
                return NotFound();
            }

            var profesion_ = await _context.Profesions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesion_ == null)
            {
                return NotFound();
            }

            _context.Add(profesion);
            await _context.SaveChangesAsync();

            return profesion_;

        }

        // DELETE api/<ProfesionesApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profesion>> Delete(int id)
        {
            if (_context.Profesions == null)
            {
                return NotFound();
            }
            var profesion_ = await _context.Profesions.FindAsync(id);
            if (profesion_ != null)
            {
                _context.Profesions.Remove(profesion_);
                await _context.SaveChangesAsync();
            }

            return profesion_;
        }
    }
}
