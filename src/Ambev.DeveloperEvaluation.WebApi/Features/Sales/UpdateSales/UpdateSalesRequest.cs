using System.Security.Cryptography.X509Certificates;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Linq;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

/// <summary>
/// Request model for updating a sale
/// </summary>
public class UpdateSalesRequest
{
    public Guid Id { get; set; } // Added Sale ID for update
    public DateTime UpdatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public List<UpdateSalesItemRequest> Items { get; set; } = new List<UpdateSalesItemRequest>();
    public bool IsCancelled { get; set; }
}

/// <summary>
/// Request model for a sale item, accepting only productId and quantity
/// </summary>
public class UpdateSalesItemRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}