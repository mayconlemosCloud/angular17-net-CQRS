using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;

/// <summary>
/// Validator for DeleteSalesRequest
/// </summary>
public class DeleteSalesRequestValidator : AbstractValidator<DeleteSalesRequest>
{
    public DeleteSalesRequestValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID is required.");
    }
}