using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.Features;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

/// <summary>
/// Command for updating a sale
/// </summary>
public class UpdateSalesCommand : IRequest<UpdateSalesResult>
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid CustomerId { get; set; }
    public string? Branch { get; set; }
    public List<UpdateSalesItemCommand> Items { get; set; } = new List<UpdateSalesItemCommand>();
    public bool IsCancelled { get; set; }
}

/// <summary>
/// Command for a sale item, accepting only productId and quantity
/// </summary>
public class UpdateSalesItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}