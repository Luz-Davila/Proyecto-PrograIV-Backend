using HackerRank1.DTO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using HackerRank1.Entities;

namespace LibraryService.WebAPI.Data
{
    // ── Entidades ─────────────────────────────────────────────
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }
    }

    public class Library
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class Abonado
    {
        [Key]
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string NumeroMedidor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
    }

    public class Averia
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string TipoAveria { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    // ── DbContext ──────────────────────────────────────────────
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Abonado> Abonados { get; set; }
        public DbSet<Averia> Averias { get; set; }
        public DbSet<InventarioItem> InventarioItems { get; set; }


        // ── LÍNEA AGREGADA: Registramos tu tabla de Averías ──
        public DbSet<Averia> Averias { get; set; }
        public DbSet<User> Users { get; set; }
    }
}