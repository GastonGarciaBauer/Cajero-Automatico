namespace CajeroMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioLogin { get; set; }
        public string Pin { get; set; }

        public List<Cuenta> Cuentas { get; set; }

    }
}