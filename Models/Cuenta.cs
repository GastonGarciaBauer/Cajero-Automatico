namespace CajeroMVC.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Titular { get; set; } = string.Empty;
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
        
        // Clave foránea para el usuario
        public int UsuarioId { get; set; }   // FK

        // Propiedad de navegación
        public Usuario Usuario { get; set; } // Relación N:1 (muchas cuentas, un usuario)
    }
}
