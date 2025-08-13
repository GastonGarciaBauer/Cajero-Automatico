using Microsoft.AspNetCore.Mvc;
using CajeroMVC.Data;
using CajeroMVC.Models;

namespace CajeroMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly CajeroContext _context;

        public UsuarioController(CajeroContext context)
        {
            _context = context;
        }
        
        // GET: /Usuario
        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }
    }
}
