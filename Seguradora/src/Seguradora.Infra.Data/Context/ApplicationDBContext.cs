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
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //REMOVE O CASCADE DELETE EM TABELAS COM RELAÇÃO N:N

            //Verifica as propriedades do dominio que são string e informa que serão varchar no banco, o padrão é nvarchar;
            modelBuilder.Properties<string>()
                .Configure(me => me.HasColumnType("VARCHAR"));

            //Verifica as propriedades do dominio que são string e seta o tamanho para 100(caso não seja informado o tamanho), o padrão é MAX;
            modelBuilder.Properties<string>()
                .Configure(me => me.HasMaxLength(100));

            //Verifica a propriedade do modelo que possui o nome do modelo + "Id" e seta essa propriedade como chave da tabela;
            modelBuilder.Properties().Where(me => me.Name == me.ReflectedType + "Id")
                .Configure(me => me.IsKey());

            //Configura cada model de acordo com o que foi definido nos seus respectivos arquivos fluent api
            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
        }

        //Sobrescrita do método SaveChanges para quando for salvo um modelo, verificar se ele possui uma propriedade "DataCadastro"
        //e caso esteja sendo adicionado, coloca a data do momento, caso o modelo esteja sendo modificado, não atualiza esse campo;
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

        // Informa ao contexto as "tabelas" disponíveis;
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
