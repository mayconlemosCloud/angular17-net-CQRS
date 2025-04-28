using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

// Moved ISalesRepository to the Domain layer
namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Interface for Sales repository
/// </summary>
public interface ISalesRepository
{
    /// <summary>
    /// Retrieves all sales
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of sales</returns>
    Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a sale by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, otherwise null</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new sale
    /// </summary>
    /// <param name="sale">The sale entity to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing sale
    /// </summary>
    /// <param name="sale">The sale entity with updated information</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale</returns>
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a sale by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, otherwise false</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}