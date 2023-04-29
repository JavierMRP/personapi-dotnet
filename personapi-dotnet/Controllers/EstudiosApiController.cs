using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace personapi_dotnet.Controllers
{
    [Route("api/Estudios")]
    [ApiController]
    public class EstudiosApiController : ControllerBase
    {

        private readonly ArqPerDbContext _context;

        public EstudiosApiController(ArqPerDbContext context)
        {
            _context = context;
        }

        // GET: api/<EstudiosApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> Get()
        {
            return await _context.Estudios.Include(e => e.CcPerNavigation).ToListAsync();
        }

        // GET api/<EstudiosApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudio>> Get(int id)
        {
            if (id == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == id);
            if (estudio == null)
            {
                return NotFound();
            }

            return estudio;
        }

        // POST api/<EstudiosApiController>
        [HttpPost]
        public async Task<ActionResult<Estudio>> Post(Estudio estudio)
        {
         
             _context.Add(estudio);
             await _context.SaveChangesAsync();
            
        
            return estudio;
        }

        // PUT api/<EstudiosApiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Estudio>> Put(int id, Estudio estudio)
        {
            if (id == null || _context.Estudios == null)
            {
                return NotFound();
            }

            var estudio_ = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(m => m.IdProf == id);
            if (estudio_ == null)
            {
                return NotFound();
            }

            _context.Add(estudio);
            await _context.SaveChangesAsync();

            return estudio_;

        }

        // DELETE api/<EstudiosApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estudio>> Delete(int id)
        {
            if (_context.Estudios == null)
            {
                return NotFound();
            }
            var estudio_ = await _context.Estudios.FindAsync(id);
            if (estudio_ != null)
            {
                _context.Estudios.Remove(estudio_);
                await _context.SaveChangesAsync();
            }

            return estudio_;
        }
    }
}
