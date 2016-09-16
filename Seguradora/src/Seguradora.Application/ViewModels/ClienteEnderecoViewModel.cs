using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguradora.Application.ViewModels
{
    public class ClienteEnderecoViewModel
    {
        public ClienteEnderecoViewModel()
        {
            ClienteId = Guid.NewGuid();
            EnderecoId = Guid.NewGuid();
        }

        [Key]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Favor preencher o nome")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor preencher a data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [MaxLength(150, ErrorMessage = "E-mail deve ter no máximo {0} caracteres")]
        public string Email { get; set; }

        [Key]
        public Guid EnderecoId { get; set; }

        [Required(ErrorMessage = "Favor preencher o CEP")]
        [MaxLength(8, ErrorMessage = "CEP deve ter {0} caracteres")]
        [MinLength(8, ErrorMessage = "CEP deve ter {0} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Favor preencher o número")]
        [MaxLength(6, ErrorMessage = "Número deve ter no máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Número deve ter no mínimo {0} caracteres")]
        public string numero { get; set; }

        [MaxLength(6, ErrorMessage = "Complemento deve ter no máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Complemento deve ter no mínimo {0} caracteres")]
        public string Complemento { get; set; }
    }
}
