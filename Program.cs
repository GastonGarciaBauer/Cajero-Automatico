using Microsoft.EntityFrameworkCore;
using CajeroMVC.Data;

namespace CajeroMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agrego el contexto de la base de datos
            builder.Services.AddDbContext<CajeroContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Agrego servicios MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Necesario para servir CSS, JS, imágenes, etc.

            app.UseRouting();

            app.UseAuthorization();

            // Configuración de las rutas
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
