using Seguradora.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Seguradora.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            ToTable("Enderecos");

            HasKey(e => e.EnderecoId);

            Property(e => e.Cep)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            Property(e => e.numero)
                .IsRequired()
                .HasMaxLength(6);

            Property(e => e.Complemento)
                .HasMaxLength(6);

            /*Relacionamento 1:1 via fluent api. Não é necessário criar a chave estrangeira na classe dependente,
             * fazendo o mapeamento abaixo o EF já cria automaticamente */
            HasOptional(e => e.cliente)
                .WithOptionalDependent(c => c.endereco)
                .Map(c => c.MapKey("ClienteId"));
            
            /*
             * Outra forma de fazer relacionamentos 1:1 via fluent api é colocar como chave da tabela dependente
             * a chave primária da tabela principal e escrever a relação abaixo.

            HasRequired(e => e.cliente)
                .WithRequiredDependent(c => c.endereco);
            */
        }
    }
}
