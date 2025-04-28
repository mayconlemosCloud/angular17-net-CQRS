using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Command for retrieving all sales
/// </summary>
public class GetAllSalesCommand : IRequest<List<GetAllSalesResult>>
{
}