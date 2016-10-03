using Seguradora.Domain.Entities;

namespace Seguradora.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorEmail(string email);
        Cliente ObterPorCpf(string cpf);
    }
}
