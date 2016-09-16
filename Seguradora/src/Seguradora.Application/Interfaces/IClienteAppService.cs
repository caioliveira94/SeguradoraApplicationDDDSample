using Seguradora.Application.ViewModels;
using Seguradora.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Seguradora.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel obj);

        ClienteViewModel ObterPorId(Guid id);

        ClienteViewModel ObterPorEmail(string email);

        IEnumerable<ClienteViewModel> ObterTodos();

        ClienteViewModel Atualizar(ClienteViewModel obj);

        void Remover(Guid id);
    }
}
