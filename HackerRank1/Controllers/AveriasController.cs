using LibraryService.WebAPI.DTO;
using LibraryService.WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AveriasController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AveriasController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/averias
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var averias = await _context.Averias.ToListAsync();
            return Ok(averias);
        }

        // GET: api/averias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var averia = await _context.Averias.FindAsync(id);
            if (averia == null) return NotFound();
            return Ok(averia);
        }

        // POST: api/averias
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AveriaForm form)
        {
            var averia = new Averia
            {
                Nombre = form.Nombre,
                TipoAveria = form.TipoAveria,
                Descripcion = form.Descripcion,
                Estado = form.Estado
            };

            _context.Averias.Add(averia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = averia.Id }, averia);
        }

        // PUT: api/averias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AveriaForm form)
        {
            var averia = await _context.Averias.FindAsync(id);
            if (averia == null) return NotFound();

            averia.Nombre = form.Nombre;
            averia.TipoAveria = form.TipoAveria;
            averia.Descripcion = form.Descripcion;
            averia.Estado = form.Estado;

            await _context.SaveChangesAsync();
            return Ok(averia);
        }

        // DELETE: api/averias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var averia = await _context.Averias.FindAsync(id);
            if (averia == null) return NotFound();

            _context.Averias.Remove(averia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}