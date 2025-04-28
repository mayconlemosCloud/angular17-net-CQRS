using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.Features;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

/// <summary>
/// Command for creating a sale
/// </summary>
public class CreateSalesCommand : IRequest<CreateSalesResult>
{
    public DateTime CreatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public List<CreateSalesItemCommand> Items { get; set; } = new List<CreateSalesItemCommand>();
    public bool IsCancelled { get; set; }

}

/// <summary>
/// Command for a sale item, accepting only productId and quantity
/// </summary>
public class CreateSalesItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}