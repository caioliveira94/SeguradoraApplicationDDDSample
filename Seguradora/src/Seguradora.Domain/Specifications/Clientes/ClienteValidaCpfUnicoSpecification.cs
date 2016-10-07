using DomainValidation.Interfaces.Specification;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Interfaces.Repository;

namespace Seguradora.Domain.Specifications.Clientes
{
    public class ClienteValidaCpfUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteValidaCpfUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorCpf(cliente.CPF) == null;
        }
    }
}
