﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seguradora.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);

        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> ObterTodos();

        TEntity Atualizar(TEntity obj);

        void Remover(Guid id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        //int SaveChanges(); Será feito através da Unit of Work
    }
}
