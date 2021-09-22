using CadastroDeClientes.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CadastroDeClientes.Infastructure.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }

        public DbSet<Cliente> clientes { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(Entry => Entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if ( entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCadastro").CurrentValue = DateTime.Now;

                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
