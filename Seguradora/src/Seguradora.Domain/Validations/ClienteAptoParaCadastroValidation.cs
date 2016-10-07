using DomainValidation.Validation;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Interfaces.Repository;
using Seguradora.Domain.Specifications.Clientes;

namespace Seguradora.Domain.Validations
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfUnico = new ClienteValidaCpfUnicoSpecification(clienteRepository);

            base.Add("CpfUnico", new Rule<Cliente>(cpfUnico, "CPF já cadastrado no sistema!"));
        }
    }
}
