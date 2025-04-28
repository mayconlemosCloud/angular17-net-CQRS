using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

/// <summary>
/// Validator for GetSalesRequest
/// </summary>
public class GetSalesRequestValidator : AbstractValidator<GetSalesRequest>
{
    public GetSalesRequestValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID is required.");
    }
}