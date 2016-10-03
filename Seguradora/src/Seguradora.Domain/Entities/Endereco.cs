using System;

namespace Seguradora.Domain.Entities
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente cliente { get; set; } //Identifica que o modelo Endereço é filho de Cliente (Relacionamento lógico para o ORM)
    }
}
