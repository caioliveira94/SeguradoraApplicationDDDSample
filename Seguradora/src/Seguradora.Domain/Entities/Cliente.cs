using System;
using System.Collections.Generic;

namespace Seguradora.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; } //Atributos externos do modelo, colocar como virtual para habilitar o lazy load
    }
}
