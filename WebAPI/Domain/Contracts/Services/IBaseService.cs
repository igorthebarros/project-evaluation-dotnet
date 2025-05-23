﻿namespace Domain.Contracts.Services
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Create a new entity, handling any business rule before sending the entity to the Repository
        /// </summary>
        /// <param name="T">The entity to be created</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created entity</returns>
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieves the entity, handling any business rule before sending the entity to the Repository
        /// </summary>
        /// <param name="id">Entity Id on Guid format</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The found entity</returns>
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve all entities, handling any business rule before sending the entity to the Repository
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of entities</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a entity, handling any business rule before sending the entity to the Repository
        /// </summary>
        /// <param name="T">The entity to be updated</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated entity</returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a entity, handling any business rule before sending the entity to the Repository
        /// </summary>
        /// <param name="id">Entity Id on Guid format</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A bool confirming if the task was successful or not</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
