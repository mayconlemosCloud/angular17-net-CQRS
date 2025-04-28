using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

/// <summary>
/// Result of updating a sale
/// </summary>
public class UpdateSalesResult
{
    public Guid SaleId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
}