namespace CajeroMVC.Models
{
    public class UsuarioCuentaViewModel
    {
        // Usuario
        public int Id { get; set; }
        public string UsuarioLogin { get; set; } = string.Empty;
        public string Pin { get; set; } = string.Empty;

        // Cuenta
        public string NumeroCuenta { get; set; } = string.Empty;
        public string Titular { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
    }
}
