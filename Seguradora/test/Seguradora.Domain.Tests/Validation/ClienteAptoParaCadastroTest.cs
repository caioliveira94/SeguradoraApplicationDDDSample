using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Interfaces.Repository;
using Seguradora.Domain.Validations;

namespace Seguradora.Domain.Tests.Validation
{
    [TestClass]
    public class ClienteAptoParaCadastroTest
    {
        public Cliente cliente { get; set; }

        [TestMethod]
        public void ClienteApto_Validation_True()
        {
            Cliente cliente = new Cliente()
            {
                CPF = "30390600822"
            };

            cliente.Enderecos.Add(new Endereco());

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(null);

            var clienteValidation = new ClienteAptoParaCadastroValidation(stubRepo);
            Assert.IsTrue(clienteValidation.Validate(cliente).IsValid);
        }

        [TestMethod]
        public void ClienteApto_Validation_False()
        {
            Cliente cliente = new Cliente()
            {
                CPF = "30390600822"
            };

            cliente.Enderecos.Add(new Endereco());

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);

            var clienteValidation = new ClienteAptoParaCadastroValidation(stubRepo);
            Assert.IsFalse(clienteValidation.Validate(cliente).IsValid);
        }
    }
}
