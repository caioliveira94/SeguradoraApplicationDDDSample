using System;

namespace Seguradora.Domain.Entities
{
    public class Endereco
    {
        public Guid EnderecoId { get; set; }
        public string Cep { get; set; }
        public string numero { get; set; }
        public string Complemento { get; set; }
        //public Guid ClienteId { get; set; } Não precisa pois o mapeamento via fluent api já vai criar essa coluna
        public Cliente cliente { get; set; }
    }
}
