using Microsoft.AspNetCore.Mvc;
using CajeroMVC.Data;
using CajeroMVC.Models;

namespace CajeroMVC.Controllers
{
    public class CuentaController : Controller
    {
        private readonly CajeroContext _context;

        public CuentaController(CajeroContext context)
        {
            _context = context;
        }

        // GET: Cuenta/Transactions/id
        public IActionResult Transactions(int id)
        {
            var cuenta = _context.Cuentas
                .Where(c => c.Id == id)
                .Select(c => new {
                    c.Id,
                    c.NumeroCuenta,
                    c.Titular,
                    Transacciones = c.Transacciones
                })
                .FirstOrDefault();

            if (cuenta == null)
                return NotFound();

            return View(cuenta.Transacciones); // Vista que muestre solo las transacciones
        }
    }
}
