using Microsoft.EntityFrameworkCore;
using CajeroMVC.Models;
using System.Collections.Generic;

namespace CajeroMVC.Data
{
    public class CajeroContext : DbContext
    {
        public CajeroContext(DbContextOptions<CajeroContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Cuenta> Cuentas { get; set; } = null!;
        public DbSet<Transaccion> Transacciones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>()
                .Property(c => c.Saldo)
                .HasPrecision(18, 2); // Esto evita truncamientos de decimal

            modelBuilder.Entity<Transaccion>()
                .Property(t => t.Monto)
                .HasPrecision(18, 2); // Igual que arriba para Monto
        }
    }
}
