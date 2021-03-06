﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seguradora.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid(); //Cliente é criado direto na aplicação
            Enderecos = new List<EnderecoViewModel>(); //Instancia uma lista vazia para ser possivel adicionar itens em tempo de execução
        }

        [Key]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Favor preencher o nome")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor preencher a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [MaxLength(150, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Favor preencher o CPF")]
        [MaxLength(11, ErrorMessage = "CPF deve ter {1} caracteres")]
        [MinLength(11, ErrorMessage = "CPF deve ter {1} caracteres")]
        public string CPF { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        public ICollection<EnderecoViewModel> Enderecos { get; set; }
    }
}
