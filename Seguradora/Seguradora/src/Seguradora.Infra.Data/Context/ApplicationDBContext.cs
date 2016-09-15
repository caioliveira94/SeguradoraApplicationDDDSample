using Seguradora.Domain.Entities;
using Seguradora.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Seguradora.Infra.Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //REMOVE CONVENÇÃO DE NOMES DE TABELA NO PLURAL
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //REMOVE O CASCADE DELETE EM TABELAS COM RELAÇÃO 1:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(me => me.HasColumnType("VARCHAR"));

            modelBuilder.Properties<string>()
                .Configure(me => me.HasMaxLength(100));

            modelBuilder.Properties().Where(me => me.Name == me.ReflectedType + "Id")
                .Configure(me => me.IsKey());

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
