using System.Security.Cryptography.X509Certificates;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Response model for creating a sale
/// </summary>
public class CreateSalesResponse
{
    public Guid SaleId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
}