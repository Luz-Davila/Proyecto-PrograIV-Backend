using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LibraryService.WebAPI.Data;
using System;

namespace LibraryService.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Construimos la aplicación primero
            var host = CreateHostBuilder(args).Build();

            // 2. Ejecutamos la verificación de la base de datos (Supabase)
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<LibraryContext>();
                    // Esto crea la tabla Averias en Supabase si no existe todavía
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    // Si algo falla al conectar, lo imprimirá en la consola negra del backend
                    Console.WriteLine($"Error al crear la tabla en Supabase: {ex.Message}");
                }
            }

            // 3. Corremos la aplicación oficialmente
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

