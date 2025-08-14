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

        // GET: Usuario/Create
        public IActionResult Create()
        {
            // Solo muestra el formulario vacío
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Si el modelo tiene errores, se vuelve a mostrar el formulario con mensajes de validación
            return View(usuario);
        }

        // GET: Usuario/Update

        public IActionResult Update() 
        {
            return View();
        }

        // POST: Usuario/Update/id
        [HttpPost]

        public IActionResult Update(int id)
        {
            var usuario = _context.Usuarios
                .Where(u => u.Id == id)
                .Select(u => new UsuarioCuentaViewModel
                {
                    Id = u.Id,
                    UsuarioLogin = u.UsuarioLogin,
                    Pin = u.Pin,
                    // Tomamos la primera cuenta del usuario como ejemplo
                    NumeroCuenta = u.Cuentas.FirstOrDefault() != null ? u.Cuentas.First().NumeroCuenta : "",
                    Titular = u.Cuentas.FirstOrDefault() != null ? u.Cuentas.First().Titular : "",
                    Saldo = u.Cuentas.FirstOrDefault() != null ? u.Cuentas.First().Saldo : 0
                })
                .FirstOrDefault();

            if (usuario == null)
                ViewBag.Mensaje = "Usuario no encontrado";

            return View(usuario);
        }

        // GET: Usuario/Delete
        public IActionResult Delete()
        {
            return View(); // muestra el formulario vacío
        }

        // POST: Usuario/Delete - Buscar usuario
        [HttpPost]
        public IActionResult DeleteBuscar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                ViewBag.Mensaje = "Usuario no encontrado.";
                return View("Delete");
            }

            return View("DeleteForm", usuario); // manda el usuario al formulario
        }

        // POST: Usuario/Delete - Confirmar eliminación
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                ViewBag.Mensaje = "Usuario no encontrado.";
                return View("Delete");
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            ViewBag.Mensaje = $"Usuario con Id {id} eliminado correctamente.";
            return View("Delete"); // vuelve al formulario vacío
        }

        // GET: Usuario/Details/id
        public IActionResult Details(int id)
        {
            // Buscar el usuario por id e incluir sus cuentas
            var usuario = _context.Usuarios
                .Where(u => u.Id == id)
                .Select(u => new {
                    u.Id,
                    u.UsuarioLogin,
                    Cuentas = u.Cuentas // Trae las cuentas asociadas
                })
                .FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            // Retornar la vista con las cuentas
            return View(usuario.Cuentas);
        }


    }
}
