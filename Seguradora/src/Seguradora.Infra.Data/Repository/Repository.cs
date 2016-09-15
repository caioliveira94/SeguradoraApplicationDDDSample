using Seguradora.Domain.Interfaces.Repository;
using Seguradora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Seguradora.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDBContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new ApplicationDBContext();
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity obj)
        {
            var retorno = DbSet.Add(obj);
            SaveChanges();
            return retorno;
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj); //Cria uma entrada de dados na memória do contexto
            DbSet.Attach(obj); //insere o objeto na memória do contexto
            entry.State = EntityState.Modified; //informa que o objeto inserido ja existe e que foi apenas modificado

            SaveChanges();

            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this); //Remove a classe da memória o quanto antes
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id); //Busca pela chave primária
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList(); //Se a tabela for muito grande, não fazer dessa forma. Fazer como abaixo.

            //Exemplo de paginação para tabelas grandes
            //return DbSet.Take(t).Skip(s).ToList(); parâmetros do método int s, int t
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
