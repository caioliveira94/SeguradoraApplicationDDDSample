using AutoMapper;
using Seguradora.Application.Interfaces;
using Seguradora.Application.ViewModels;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Interfaces.Services;
using Seguradora.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Seguradora.Application
{
    public class ClienteAppService : IClienteAppService
    {

        private readonly IClienteService _clienteService;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork unitOfWork)
        {
            _clienteService = clienteService;
            _unitOfWork = unitOfWork;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEndereco)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEndereco);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEndereco);

            cliente.Enderecos.Add(endereco);

            //Unit of Work - Responsável por persistir no BD
            _unitOfWork.BeginTransaction();
            _clienteService.Adicionar(cliente);

            //Aqui ficaria a validação do dominio se vai gravar ou não
            _unitOfWork.Commit();

            return clienteEndereco;
        }

        public ClienteViewModel Atualizar(ClienteViewModel cliente)
        {
            //Unit of Work - Responsável por persistir no BD
            _unitOfWork.BeginTransaction();
            _clienteService.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(cliente));
            _unitOfWork.Commit();

            return cliente;
        }

        public void Dispose()
        {
            _clienteService.Dispose();
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            //Unit of Work - Responsável por persistir no BD
            _unitOfWork.BeginTransaction();
            _clienteService.Remover(id);
            _unitOfWork.Commit();

            GC.SuppressFinalize(this);
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }
    }
}
