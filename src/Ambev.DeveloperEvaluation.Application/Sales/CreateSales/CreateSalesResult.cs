using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

/// <summary>
/// Result of creating a sale
/// </summary>
public class CreateSalesResult
{
    public Guid SaleId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
}