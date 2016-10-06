using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seguradora.Domain.Entities;
using System.Linq;

namespace Seguradora.Domain.Tests.Entity
{
    [TestClass]
    public class ClienteTest
    {
        public Cliente cliente { get; set; }

        [TestMethod]
        public void ClienteConsistente_Valid_True()
        {
            cliente = new Cliente()
            {
                CPF = "11906942633",
                Email = "cliente@cliente.com"
            };

            Assert.IsTrue(cliente.IsValid());
        }

        [TestMethod]
        public void ClienteConsistente_Valid_False()
        {
            cliente = new Cliente()
            {
                CPF = "11806942633",
                Email = "cliente#cliente.com"
            };

            Assert.IsFalse(cliente.IsValid());
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou E-mail inválido."));
        }
    }
}
