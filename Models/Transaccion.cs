namespace CajeroMVC.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}