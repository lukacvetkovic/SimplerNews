﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataModel.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        void Delete(Func<TEntity, bool> where);
        bool Exists(object primaryKey);
        IEnumerable<TEntity> Get();
        TEntity Get(Func<TEntity, bool> where);
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(object id);
        TEntity GetFirst(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
        IEnumerable<TEntity> GetTopMany(Func<TEntity, bool> where, int number);
        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);
        TEntity GetSingle(Func<TEntity, bool> predicate);
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);
        void Insert(TEntity entity);
        IEnumerable<TEntity> Query();
        void Update(TEntity entityToUpdate);
    }
}