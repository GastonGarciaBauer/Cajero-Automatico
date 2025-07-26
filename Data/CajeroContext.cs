using Microsoft.EntityFrameworkCore;
using CajeroMVC.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CajeroMVC.Data
{
    public class CajeroContext : DbContext
    {
        public CajeroContext(DbContextOptions<CajeroContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        // Configuración extra (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Usuario -> Cuentas
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Cuentas)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);

            // Relación Cuenta -> Transacciones
            modelBuilder.Entity<Cuenta>()
                .HasMany(c => c.Transacciones)
                .WithOne(t => t.Cuenta)
                .HasForeignKey(t => t.CuentaId);
        }
    }
}
