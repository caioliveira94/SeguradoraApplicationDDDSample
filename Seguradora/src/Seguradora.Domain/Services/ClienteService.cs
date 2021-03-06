﻿using Seguradora.Domain.Entities;
using Seguradora.Domain.Interfaces.Repository;
using Seguradora.Domain.Interfaces.Services;
using Seguradora.Domain.Validations;
using System;
using System.Collections.Generic;

namespace Seguradora.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            //Verifica se o cliente está válido (Validações que não utilizam banco)
            if (!cliente.IsValid())
            {
                return cliente;
            }

            //Validações que dependem do banco
            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if(!cliente.ValidationResult.IsValid)
            {
                return cliente;
            }

            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
