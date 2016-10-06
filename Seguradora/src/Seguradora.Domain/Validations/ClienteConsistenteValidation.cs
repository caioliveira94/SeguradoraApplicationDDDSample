using DomainValidation.Validation;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Specifications.Clientes;

namespace Seguradora.Domain.Validations
{
    public class ClienteConsistenteValidation : Validator<Cliente>
    {
        public ClienteConsistenteValidation()
        {
            var CpfCliente = new ClienteValidaCpfSpecification();
            var clienteEmail = new ClienteValidaEmailSpecification();

            base.Add("CPF", new Rule<Cliente>(CpfCliente, "Cliente informou CPF inválido."));
            base.Add("Email", new Rule<Cliente>(clienteEmail, "Cliente informou E-mail inválido."));
        }
    }
}
