using DomainValidation.Interfaces.Specification;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Validations;

namespace Seguradora.Domain.Specifications.Clientes
{
    public class ClienteValidaCpfSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CpfValidation.Validar(cliente.CPF);
        }
    }
}
