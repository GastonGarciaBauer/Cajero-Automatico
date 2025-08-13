namespace CajeroMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioLogin { get; set; } = string.Empty;
        public string Pin { get; set; } = string.Empty;
        public List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
    }
}