using System;
using System.ComponentModel.DataAnnotations;

namespace Seguradora.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid();
        }

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
