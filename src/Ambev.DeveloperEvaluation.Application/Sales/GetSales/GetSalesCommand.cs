using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Command for retrieving a sale
/// </summary>
public class GetSalesCommand : IRequest<GetSalesResult>
{
    public Guid SaleId { get; set; }
}