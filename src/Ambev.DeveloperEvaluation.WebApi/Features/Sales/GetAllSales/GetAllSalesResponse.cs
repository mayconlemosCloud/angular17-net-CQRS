using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesResponse
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