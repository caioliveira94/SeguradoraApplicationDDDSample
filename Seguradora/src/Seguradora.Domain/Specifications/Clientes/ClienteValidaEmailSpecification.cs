using DomainValidation.Interfaces.Specification;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Validations;

namespace Seguradora.Domain.Specifications.Clientes
{
    public class ClienteValidaEmailSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validate(cliente.Email);
        }
    }
}
