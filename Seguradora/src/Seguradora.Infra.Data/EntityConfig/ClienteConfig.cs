using Seguradora.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Seguradora.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            ToTable("Clientes");

            HasKey(c => c.ClienteId);

            Property(c => c.nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .HasMaxLength(150);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();
        }
    }
}
