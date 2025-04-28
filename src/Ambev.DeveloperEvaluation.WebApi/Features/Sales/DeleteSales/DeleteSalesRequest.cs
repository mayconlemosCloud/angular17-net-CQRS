namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;

/// <summary>
/// Request model for deleting a sale
/// </summary>
public class DeleteSalesRequest
{
    public Guid SaleId { get; set; }
}