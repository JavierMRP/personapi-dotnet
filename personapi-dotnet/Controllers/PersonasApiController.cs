using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/Personas")]
    [ApiController]
    public class PersonasApiController : Controller
    {

        private readonly ArqPerDbContext _context;

        public PersonasApiController(ArqPerDbContext context)
        {
            _context = context;
        }
        // GET: api/<PersonasApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> Get()
        {
            return await _context.Personas.ToListAsync();
        }

        // GET api/<PersonasApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var Persona = await _context.Personas
                .Include(e => e.Cc)
                .FirstOrDefaultAsync(m => m.Cc == id);
            if (Persona == null)
            {
                return NotFound();
            }

            return Persona;
        }

        // POST api/<PersonasApiController>
        [HttpPost]
        public async Task<ActionResult<Persona>> Post(Persona persona)
        {

            _context.Add(persona);
            await _context.SaveChangesAsync();


            return persona;
        }

        // PUT api/<PersonasApiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Persona>> Put(int id, Persona persona)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona_ = await _context.Personas
                .FirstOrDefaultAsync(m => m.Cc == id);
            if (persona_ == null)
            {
                return NotFound();
            }

            _context.Add(persona);
            await _context.SaveChangesAsync();

            return persona_;

        }

        // DELETE api/<PersonasApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persona>> Delete(int id)
        {
            if (_context.Personas == null)
            {
                return NotFound();
            }
            var persona_ = await _context.Personas.FindAsync(id);
            if (persona_ != null)
            {
                _context.Personas.Remove(persona_);
                await _context.SaveChangesAsync();
            }

            return persona_;
        }
    }
}
