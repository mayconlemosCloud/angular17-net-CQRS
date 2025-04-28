using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

/// <summary>
/// Validator for DeleteSalesCommand
/// </summary>
public class DeleteSalesValidator : AbstractValidator<DeleteSalesCommand>
{
    public DeleteSalesValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID is required.");
    }
}