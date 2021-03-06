﻿using System;

using Dal.Core.Interfaces.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Data.Entity;

namespace Dal.Core.Interfaces
{
    /// <summary>
    /// Represents an unit container for all repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable, ISaveable
    {

        int CallStoredProcedure(string nameOfProcedure, params int[] parameters);
        List<T> CallFunction<T>(string nameOfFunction, params string[] parameters);
        /// <summary>
        /// Returns a repository to interaction with <typeparamref name="TEntity"/> instances
        /// </summary>
        /// <typeparam name="TEntity">Entity type, for which repository is required</typeparam>
        /// <typeparam name="TKey">Entity's id type</typeparam>
        /// <returns></returns>
        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class, IKeyable<TKey>;


        /// <summary>
        ///  Executes the given DDL/DML command against the database. 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params Object[] parameters);

        /// <summary>
        ///  Executes the given DDL/DML command against the database. 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(TransactionalBehavior transactionakBehavior, String sql, params Object[] parameters);

     
        /// <summary>
        /// Gets a DbEntityEntry<TEntity> object for the given entity providing access to information about the entity and the ability to perform actions on the entity.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;



    }
}