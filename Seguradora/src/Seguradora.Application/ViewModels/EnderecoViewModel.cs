﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Seguradora.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid(); //Endereço é criado direto na aplicação
        }

        [Key]
        public Guid EnderecoId { get; set; }

        [Required(ErrorMessage = "Favor preencher o CEP")]
        [MaxLength(8, ErrorMessage = "CEP deve ter {1} caracteres")]
        [MinLength(8, ErrorMessage = "CEP deve ter {1} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Favor preencher o número")]
        [MaxLength(6, ErrorMessage = "Número deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "Número deve ter no mínimo {1} caracteres")]
        public string numero { get; set; }

        [MaxLength(6, ErrorMessage = "Complemento deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "Complemento deve ter no mínimo {1} caracteres")]
        public string Complemento { get; set; }

        [MaxLength(256, ErrorMessage = "Logradouro deve ter no máximo {1} caracteres")]
        [MinLength(5, ErrorMessage = "Logradouro deve ter no mínimo {1} caracteres")]
        public string Logradouro { get; set; }

        [MaxLength(150, ErrorMessage = "Bairro deve ter no máximo {1} caracteres")]
        [MinLength(5, ErrorMessage = "Bairro deve ter no mínimo {1} caracteres")]
        public string Bairro { get; set; }

        [MaxLength(200, ErrorMessage = "Cidade deve ter no máximo {1} caracteres")]
        [MinLength(3, ErrorMessage = "Cidade deve ter no mínimo {1} caracteres")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "Estado deve ter {1} caracteres")]
        [MinLength(2, ErrorMessage = "Estado deve ter {1} caracteres")]
        public string Estado { get; set; }
    }
}
