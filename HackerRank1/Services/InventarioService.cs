using HackerRank1.DTO;
using HackerRank1.Entities;
using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HackerRank1.Services
{
    public class InventarioService
    {
        private readonly LibraryContext _context;

        public InventarioService(LibraryContext context)
        {
            _context = context;
        }

        // GET: Obtener todos los productos mapeados a DTO
        public async Task<List<InventarioDto>> ObtenerTodosAsync()
        {
            return await _context.InventarioItems
                .Select(item => new InventarioDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Categoria = item.Categoria,
                    Cantidad = item.Cantidad,
                    Estado = item.Estado,
                    Uso = item.Uso,
                    Imagen = item.Imagen,
                    Activo = item.Activo
                })
                .ToListAsync();
        }

        // POST: Agregar un nuevo producto a partir del Form de React
        public async Task AgregarProductoAsync(InventarioForm form)
        {
            var nuevoItem = new InventarioItem
            {
                Nombre = form.Nombre,
                Categoria = form.Categoria,
                Cantidad = form.Cantidad,
                Estado = form.Estado,
                Uso = form.Uso,
                Imagen = form.Imagen,
                Activo = true // Por defecto ingresa activo
            };

            _context.InventarioItems.Add(nuevoItem);
            await _context.SaveChangesAsync();
        }

        // PUT: Cambiar estado (Activo/Inactivo)
        public async Task<bool> CambiarEstadoAsync(int id, bool activo)
        {
            var item = await _context.InventarioItems.FindAsync(id);
            if (item == null) return false;

            item.Activo = activo;
            await _context.SaveChangesAsync();
            return true;
        }

        // PUT: Actualizar cantidad (Sumar/Restar)
        public async Task<bool> ActualizarCantidadAsync(int id, int nuevaCantidad)
        {
            var item = await _context.InventarioItems.FindAsync(id);
            if (item == null) return false;

            item.Cantidad = nuevaCantidad;
            await _context.SaveChangesAsync();
            return true;
        }

        // 🚀 DELETE: Eliminar permanentemente un producto de la base de datos
        public async Task<bool> EliminarProductoAsync(int id)
        {
            var item = await _context.InventarioItems.FindAsync(id);

            // Si el ID no existe en la base de datos, retornamos false
            if (item == null) return false;

            // Removemos el registro del DbSet y guardamos cambios en la BD
            _context.InventarioItems.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}