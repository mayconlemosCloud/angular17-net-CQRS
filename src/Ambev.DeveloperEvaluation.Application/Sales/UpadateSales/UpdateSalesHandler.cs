using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

/// <summary>
/// Handler for processing UpdateSalesCommand
/// </summary>
public class UpdateSalesHandler : IRequestHandler<UpdateSalesCommand, UpdateSalesResult>
{
    private readonly IMapper _mapper;
    private readonly ISalesRepository _salesRepository;
    private readonly IProductRepository _productRepository;

    public UpdateSalesHandler(IMapper mapper, ISalesRepository salesRepository, IProductRepository productRepository)
    {
        _mapper = mapper;
        _salesRepository = salesRepository;
        _productRepository = productRepository;
    }

    public async Task<UpdateSalesResult> Handle(UpdateSalesCommand request, CancellationToken cancellationToken)
    {

        // Validate the request
        var validator = new UpdateSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }


        var salesEntity = await _salesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (salesEntity == null)
        {
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found.");
        }


        var allProducts = await _productRepository.GetAllAsync();


        decimal totalDiscount = 0;


        salesEntity.TotalAmount = request.Items.Sum(item =>
        {
            var product = allProducts.FirstOrDefault(p => p.Id == item.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with ID {item.ProductId} not found.");
            }

            var itemTotal = item.Quantity * product.UnitPrice;
            decimal itemDiscount = 0;

            // Aplica descontos
            if (item.Quantity > 4 && item.Quantity < 10)
            {
                itemDiscount = itemTotal * 0.1m; // 10% de desconto
                itemTotal -= itemDiscount;
            }
            else if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                itemDiscount = itemTotal * 0.2m; // 20% de desconto
                itemTotal -= itemDiscount;
            }

            totalDiscount += itemDiscount;
            return itemTotal;
        });


        salesEntity.Discount = totalDiscount;

        _mapper.Map(request, salesEntity);

        var result = await _salesRepository.UpdateAsync(salesEntity, cancellationToken);
        if (result == null)
        {
            throw new Exception("Error updating sale");
        }

        return _mapper.Map<UpdateSalesResult>(result);
    }
}