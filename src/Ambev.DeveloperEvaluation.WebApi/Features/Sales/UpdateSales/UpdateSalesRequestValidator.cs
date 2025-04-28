using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

/// <summary>
/// Validator for UpdateSalesRequest
/// </summary>
public class UpdateSalesRequestValidator : AbstractValidator<UpdateSalesRequest>
{
    public UpdateSalesRequestValidator()
    {
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID is required.");
        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId).NotEmpty().WithMessage("Product ID is required.");
            items.RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            items.RuleFor(i => i.Quantity).LessThanOrEqualTo(20).WithMessage("Quantity must be less than or equal to 20.");
        });
    }
}