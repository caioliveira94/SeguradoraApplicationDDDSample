using Seguradora.Domain.Entities;
using Seguradora.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguradora.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }
    }
}
