using System;

namespace Seguradora.Domain.Entities
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public Endereco endereco { get; set; }
    }
}
