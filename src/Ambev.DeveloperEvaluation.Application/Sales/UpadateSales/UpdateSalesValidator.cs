using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

/// <summary>
/// Validator for UpdateSalesCommand
/// </summary>
public class UpdateSalesValidator : AbstractValidator<UpdateSalesCommand>
{
    public UpdateSalesValidator()
    {
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID is required.");
        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId).NotEmpty().WithMessage("Product ID is required.");
            items.RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            items.RuleFor(i => i.Quantity).LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");
        });
    }
}