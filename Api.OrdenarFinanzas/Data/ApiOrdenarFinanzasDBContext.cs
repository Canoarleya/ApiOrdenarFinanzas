using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.OrdenarFinanzas.Data.Models;
using Api.OrdenarFinanzas.Services;

namespace Api.OrdenarFinanzas.Data
{
    public class ApiOrdenarFinanzasDBContext : DbContext
    {
        public ApiOrdenarFinanzasDBContext (DbContextOptions<ApiOrdenarFinanzasDBContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Periodicidad> Periodicidades { get; set; }
        public DbSet<TipoGastoFijo> TiposGastosFijos { get; set; }
        public DbSet<GastoFijo> GastosFijos { get; set; }
        public DbSet<MetaAhorro> MetasAhorro { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<TipoPago> TiposPago { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Periodicidad>().ToTable(nameof(Periodicidad));
            modelBuilder.Entity<TipoGastoFijo>().ToTable(nameof(TipoGastoFijo));
            modelBuilder.Entity<GastoFijo>().ToTable(nameof(GastoFijo));
            modelBuilder.Entity<MetaAhorro>().ToTable(nameof(MetaAhorro));
            modelBuilder.Entity<Pago>().ToTable(nameof(Pago));
            modelBuilder.Entity<TipoPago>().ToTable(nameof(TipoPago));
            //modelBuilder.Entity<Pago>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

    }
}
