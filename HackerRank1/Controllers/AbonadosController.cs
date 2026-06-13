using LibraryService.WebAPI.DTO;
using LibraryService.WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AbonadosController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AbonadosController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/abonados
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var abonados = await _context.Abonados.ToListAsync();
            return Ok(abonados);
        }

        // GET: api/abonados/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var abonado = await _context.Abonados.FindAsync(id);
            if (abonado == null) return NotFound();
            return Ok(abonado);
        }

        // POST: api/abonados
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AbonadoForm form)
        {
            var abonado = new Abonado
            {
                NombreCompleto = form.NombreCompleto,
                Cedula = form.Cedula,
                NumeroMedidor = form.NumeroMedidor,
                Direccion = form.Direccion,
                Telefono = form.Telefono,
                Estado = form.Estado
            };

            _context.Abonados.Add(abonado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = abonado.Id }, abonado);
        }

        // PUT: api/abonados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AbonadoForm form)
        {
            var abonado = await _context.Abonados.FindAsync(id);
            if (abonado == null) return NotFound();

            abonado.NombreCompleto = form.NombreCompleto;
            abonado.Cedula = form.Cedula;
            abonado.NumeroMedidor = form.NumeroMedidor;
            abonado.Direccion = form.Direccion;
            abonado.Telefono = form.Telefono;
            abonado.Estado = form.Estado;

            await _context.SaveChangesAsync();
            return Ok(abonado);
        }

        // DELETE: api/abonados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var abonado = await _context.Abonados.FindAsync(id);
            if (abonado == null) return NotFound();

            _context.Abonados.Remove(abonado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}