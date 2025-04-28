using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Query for retrieving all sales
/// </summary>
public class GetAllSalesQuery : IRequest<List<GetAllSalesResult>>
{
}