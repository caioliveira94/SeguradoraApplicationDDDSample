using DomainValidation.Validation;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Specifications.Clientes;

namespace Seguradora.Domain.Validations
{
    public class ClienteConsistenteValidation : Validator<Cliente>
    {
        //Composição de regras de negócio menores e mais específicas
        public ClienteConsistenteValidation()
        {
            var CpfCliente = new ClienteValidaCpfSpecification();
            var clienteEmail = new ClienteValidaEmailSpecification();

            //Adiciona na classe base uma regra, que consiste em uma specification criada e uma msg de erro.
            base.Add("CPF", new Rule<Cliente>(CpfCliente, "Cliente informou CPF inválido."));
            base.Add("Email", new Rule<Cliente>(clienteEmail, "Cliente informou E-mail inválido."));
        }
    }
}
