using Seguradora.Application.ViewModels;
using Seguradora.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Seguradora.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        Cliente Adicionar(Cliente obj);

        ClienteViewModel ObterPorId(Guid id);

        ClienteViewModel ObterPorTelefone(string email);

        IEnumerable<ClienteViewModel> ObterTodos();

        ClienteViewModel Atualizar(ClienteViewModel obj);

        void Remover(Guid id);
    }
}
