using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

/// <summary>
/// Command for deleting a sale
/// </summary>
public class DeleteSalesCommand : IRequest<DeleteSalesResponse>
{
    public Guid SaleId { get; set; }
}