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

        public Repository(ApplicationDBContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            return DbSet.Add(obj);
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj); //Cria uma entrada de dados na memória do contexto
            DbSet.Attach(obj); //insere o objeto na memória do contexto
            entry.State = EntityState.Modified; //informa que o objeto inserido ja existe e que foi apenas modificado

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

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id); //Busca pela chave primária
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList(); //Se a tabela for muito grande, não fazer dessa forma. Fazer como abaixo.

            //Exemplo de paginação para tabelas grandes
            //return DbSet.Take(t).Skip(s).ToList(); parâmetros do método int s, int t
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

    }
}
