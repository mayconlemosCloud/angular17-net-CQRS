using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Validator for CreateSalesRequest
/// </summary>
public class CreateSalesRequestValidator : AbstractValidator<CreateSalesRequest>
{
    public CreateSalesRequestValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");
        RuleFor(x => x.Items).NotEmpty().WithMessage("At least one item is required.");
        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId).NotEmpty().WithMessage("Product ID is required.");
            items.RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            items.RuleFor(i => i.Quantity).LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");
        });
    }
}