using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    /// <summary>
    /// Interface for the repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of elements in repository.</typeparam>
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Get all elements.
        /// </summary>
        /// <returns>Enumerable of all elements.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get all elements.
        /// </summary>
        /// <returns>Enumerable of all elements.</returns>
        IEnumerable<TEntity> GetAll(string name, string surname);

        /// <summary>
        /// Get element by id.
        /// </summary>
        /// <param name="id">id of element</param>
        /// <returns>Finding element.</returns>
        TEntity GetById(string id);

        /// <summary>
        /// Get element by predicate.
        /// </summary>
        /// <param name="predicate">predicate for finding element</param>
        /// <returns>Finding element.</returns>
        TEntity GetByPredicate(Predicate<TEntity> predicate);

        /// <summary>
        /// Add new element.
        /// </summary>
        /// <param name="entity">adding element</param>
        void Create(TEntity entity);

        /// <summary>
        /// Delete element.
        /// </summary>
        /// <param name="entity">deleting element</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Update element.
        /// </summary>
        /// <param name="entity">updating element</param>
        void Update(TEntity entity);
    }
}
