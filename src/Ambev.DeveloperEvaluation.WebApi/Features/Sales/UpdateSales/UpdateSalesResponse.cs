using System.Security.Cryptography.X509Certificates;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

/// <summary>
/// Response model for updating a sale
/// </summary>
public class UpdateSalesResponse
{
    public Guid SaleId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
}