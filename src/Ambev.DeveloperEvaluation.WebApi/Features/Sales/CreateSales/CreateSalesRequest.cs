using System.Security.Cryptography.X509Certificates;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Linq;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Request model for creating a sale
/// </summary>
public class CreateSalesRequest
{
    public DateTime CreatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public List<CreateSalesItemRequest> Items { get; set; } = new List<CreateSalesItemRequest>();
    public bool IsCancelled { get; set; }
}

/// <summary>
/// Request model for a sale item, accepting only productId
/// </summary>
public class CreateSalesItemRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }// Added UnitPrice to calculate TotalAmount
}