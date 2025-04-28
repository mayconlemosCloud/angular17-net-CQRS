using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Result of retrieving all sales
/// </summary>
public class GetAllSalesResult
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public string? Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
    public bool IsCancelled { get; set; }
}