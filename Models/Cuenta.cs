namespace CajeroMVC.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Transaccion> Transacciones { get; set; }

    }
}