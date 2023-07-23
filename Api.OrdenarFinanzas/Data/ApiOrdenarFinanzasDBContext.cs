using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.OrdenarFinanzas.Data.Models;

namespace Api.OrdenarFinanzas.Data
{
    public class ApiOrdenarFinanzasDBContext : DbContext
    {
        public ApiOrdenarFinanzasDBContext (DbContextOptions<ApiOrdenarFinanzasDBContext> options)
            : base(options)
        {
        }

        public DbSet<Api.OrdenarFinanzas.Data.Models.Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            //modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            //modelBuilder.Entity<User>().ToTable(nameof(User));

            base.OnModelCreating(modelBuilder);
        }

    }
}
