using Seguradora.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Seguradora.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);

        Cliente ObterPorId(Guid id);

        Cliente ObterPorEmail(string email);

        Cliente ObterPorCpf(string cpf);

        IEnumerable<Cliente> ObterTodos();

        Cliente Atualizar(Cliente cliente);

        void Remover(Guid id);
    }
}
