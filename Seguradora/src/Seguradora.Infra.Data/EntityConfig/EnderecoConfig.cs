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

            Property(e => e.CEP)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(6);

            Property(e => e.Complemento)
                .HasMaxLength(6);

            Property(e => e.Logradouro)
                .HasMaxLength(256)
                .IsRequired();

            Property(e => e.Cidade)
                .HasMaxLength(200)
                .IsRequired();

            Property(e => e.Estado)
                .HasMaxLength(2)
                .IsRequired();

            // Relacionamento 1:N, feito no lado "N" do relacionamento;
            HasRequired(e => e.cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            /*Relacionamento 1:1 via fluent api. Não é necessário criar a chave estrangeira na classe dependente,
             * fazendo o mapeamento abaixo o EF já cria automaticamente 
            HasOptional(e => e.cliente)
                .WithOptionalDependent(c => c.endereco)
                .Map(c => c.MapKey("ClienteId"));*/

            /*
             * Outra forma de fazer relacionamentos 1:1 via fluent api é colocar como chave da tabela dependente
             * a chave primária da tabela principal e escrever a relação abaixo.

            HasRequired(e => e.cliente)
                .WithRequiredDependent(c => c.endereco);
            */

            /* Exemplo mapeamento N:N
               HasMany(e => e.cliente)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("");
                    me.MapRightKey("");
                    me.ToTable("TabelaLógicaORM");
                });
            */
        }
    }
}
