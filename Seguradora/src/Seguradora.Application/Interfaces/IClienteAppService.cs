using Seguradora.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Seguradora.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEndereco);

        ClienteViewModel ObterPorId(Guid id);

        ClienteViewModel ObterPorEmail(string email);

        ClienteViewModel ObterPorCpf(string cpf);

        IEnumerable<ClienteViewModel> ObterTodos();

        ClienteViewModel Atualizar(ClienteViewModel cliente);

        void Remover(Guid id);
    }
}
