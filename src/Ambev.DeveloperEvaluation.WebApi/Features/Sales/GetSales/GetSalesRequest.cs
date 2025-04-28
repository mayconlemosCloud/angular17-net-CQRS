namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

/// <summary>
/// Request model for retrieving a sale
/// </summary>
public class GetSalesRequest
{
    public Guid SaleId { get; set; }
}