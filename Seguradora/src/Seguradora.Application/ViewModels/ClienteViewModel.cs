using System;
using System.ComponentModel.DataAnnotations;

namespace Seguradora.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
        }

        [Key]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Favor preencher o nome")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor preencher a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [MaxLength(150, ErrorMessage = "E-mail deve ter no máximo {0} caracteres")]
        public string Email { get; set; }

        public EnderecoViewModel endereco { get; set; }
    }
}
