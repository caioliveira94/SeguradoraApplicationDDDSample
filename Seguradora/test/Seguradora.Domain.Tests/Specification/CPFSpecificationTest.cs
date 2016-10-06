using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Specifications.Clientes;

namespace Seguradora.Domain.Tests.Specification
{
    [TestClass]
    public class CPFSpecificationTest
    {
        public Cliente cliente { get; set; }

        [TestMethod]
        public void CPF_Valid_True()
        {
            cliente = new Cliente()
            {
                CPF = "11906942633"
            };

            var cpf = new ClienteValidaCpfSpecification();

            Assert.IsTrue(cpf.IsSatisfiedBy(cliente));
        }

        [TestMethod]
        public void CPF_Valid_False()
        {
            cliente = new Cliente()
            {
                CPF = "11906842633"
            };

            var cpf = new ClienteValidaCpfSpecification();

            Assert.IsFalse(cpf.IsSatisfiedBy(cliente));
        }
    }
}
