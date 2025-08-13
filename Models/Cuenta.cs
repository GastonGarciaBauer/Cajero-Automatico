using System.Transactions;

namespace CajeroMVC.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Titular { get; set; } = string.Empty;
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
    }
}
