using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/Telefonos")]
    [ApiController]
    public class TelefonosApiController : Controller
    {
    private readonly ArqPerDbContext _context;

    public TelefonosApiController(ArqPerDbContext context)
    {
        _context = context;
    }

    // GET: api/<TelefonoesApiController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Telefono>>> Get()
    {
        return await _context.Telefonos.ToListAsync();
    }

    // GET api/<TelefonoesApiController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Telefono>> Get(string id)
    {
        if (id == null || _context.Telefonos == null)
        {
            return NotFound();
        }

        var Telefono = await _context.Telefonos
            .Include(e => e.Num)
            .FirstOrDefaultAsync(m => m.Num == id);
        if (Telefono == null)
        {
            return NotFound();
        }

        return Telefono;
    }

    // POST api/<TelefonoesApiController>
    [HttpPost]
    public async Task<ActionResult<Telefono>> Post(Telefono telefono)
    {

        _context.Add(telefono);
        await _context.SaveChangesAsync();


        return telefono;
    }

    // PUT api/<TelefonoesApiController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Telefono>> Put(string id, Telefono telefono)
    {
        if (id == null || _context.Telefonos == null)
        {
            return NotFound();
        }

        var telefono_ = await _context.Telefonos
            .FirstOrDefaultAsync(m => m.Num == id);
        if (telefono_ == null)
        {
            return NotFound();
        }

        _context.Add(telefono);
        await _context.SaveChangesAsync();

        return telefono_;

    }

    // DELETE api/<TelefonoesApiController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Telefono>> Delete(string id)
    {
        if (_context.Telefonos == null)
        {
            return NotFound();
        }
        var telefono_ = await _context.Telefonos.FindAsync(id);
        if (telefono_ != null)
        {
            _context.Telefonos.Remove(telefono_);
            await _context.SaveChangesAsync();
        }

        return telefono_;
    }
}
}
