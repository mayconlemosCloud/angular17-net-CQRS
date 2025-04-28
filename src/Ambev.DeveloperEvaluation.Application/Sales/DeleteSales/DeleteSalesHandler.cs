
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

/// <summary>
/// Handler for processing DeleteSalesCommand
/// </summary>
public class DeleteSalesHandler : IRequestHandler<DeleteSalesCommand, DeleteSalesResponse>
{
    private readonly ISalesRepository _salesRepository;

    public DeleteSalesHandler(ISalesRepository salesRepository)
    {
        _salesRepository = salesRepository;
    }

    public async Task<DeleteSalesResponse> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _salesRepository.DeleteAsync(request.SaleId, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Sales with ID {request.SaleId} not found");

        return new DeleteSalesResponse { Success = true };
    }
}