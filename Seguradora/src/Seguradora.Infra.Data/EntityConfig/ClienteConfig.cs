using Seguradora.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguradora.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            ToTable("Clientes");

            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .HasMaxLength(150);

            Property(c => c.CPF)
                .HasMaxLength(11)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true })); //Exemplo de criação de índice

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();

            Ignore(c => c.ValidationResult);
        }
    }
}
