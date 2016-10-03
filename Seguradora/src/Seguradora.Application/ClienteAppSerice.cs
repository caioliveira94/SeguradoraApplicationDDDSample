using AutoMapper;
using Seguradora.Application.Interfaces;
using Seguradora.Application.ViewModels;
using Seguradora.Domain.Entities;
using Seguradora.Infra.Data.Repository;
using System;
using System.Collections.Generic;

namespace Seguradora.Application
{
    public class ClienteAppSerice : IClienteAppService
    {

        private readonly ClienteRepository _clienteRepository;

        public ClienteAppSerice()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEndereco)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEndereco);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEndereco);

            cliente.Enderecos.Add(endereco);

            _clienteRepository.Adicionar(cliente);

            return clienteEndereco;
        }

        public ClienteViewModel Atualizar(ClienteViewModel cliente)
        {
            _clienteRepository.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(cliente));

            return cliente;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
            GC.SuppressFinalize(this);
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
