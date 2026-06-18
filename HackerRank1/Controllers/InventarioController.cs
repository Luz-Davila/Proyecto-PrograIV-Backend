using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HackerRank1.DTO;
using HackerRank1.Services;

namespace HackerRank1.Controllers
{
    //[Authorize] // REQUISITO: Protege todo el controlador con JWT
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly InventarioService _inventarioService;

        // Inyectamos el servicio que acabamos de crear
        public InventarioController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerInventario()
        {
            var inventario = await _inventarioService.ObtenerTodosAsync();
            return Ok(inventario);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto([FromBody] InventarioForm dto)
        {
            if (dto == null) return BadRequest("Datos inválidos");

            await _inventarioService.AgregarProductoAsync(dto);
            return Ok(new { message = "Producto guardado con éxito en Supabase" });
        }

        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] bool activo)
        {
            var modificado = await _inventarioService.CambiarEstadoAsync(id, activo);

            if (!modificado)
                return NotFound(new { message = "El producto no fue encontrado" });

            return NoContent();
        }

        [HttpPut("{id}/cantidad")]
        public async Task<IActionResult> ActualizarCantidad(int id, [FromBody] int nuevaCantidad)
        {
            if (nuevaCantidad < 0) return BadRequest("La cantidad no puede ser negativa");

            var modificado = await _inventarioService.ActualizarCantidadAsync(id, nuevaCantidad);

            if (!modificado)
                return NotFound(new { message = "El producto no fue encontrado" });

            return NoContent();
        }

        // 🚀 NUEVO ENDPOINT: Borrado físico por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var eliminado = await _inventarioService.EliminarProductoAsync(id);

            if (!eliminado)
                return NotFound(new { message = "El producto no pudo ser encontrado" });

            return Ok(new { message = $"Producto con ID {id} eliminado correctamente" });
        }
    }
}