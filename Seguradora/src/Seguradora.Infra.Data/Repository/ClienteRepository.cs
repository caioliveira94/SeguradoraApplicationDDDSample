using Dapper;
using Seguradora.Domain.Entities;
using Seguradora.Domain.Interfaces.Repository;
using Seguradora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seguradora.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDBContext context)
            :base(context)
        {

        }

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

        //Leitura de dados utilizando Dapper
        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes";

            //Comando "Query" chama o Dapper
            return cn.Query<Cliente>(sql);
        }

        //Leitura de dados utilizando Dapper
        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Enderecos e " + 
                       "ON c.ClienteId = e.ClienteId " + 
                       "WHERE c.ClienteId = @sid";

            //Retorna o Cliente e Endereco e vai inserir essas informações em Cliente
            var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            return cliente.FirstOrDefault();
        }
    }
}
