using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

/// <summary>
/// Handler for processing CreateSalesCommand
/// </summary>
public class CreateSalesHandler : IRequestHandler<CreateSalesCommand, CreateSalesResult>
{
    private readonly IMapper _mapper;
    private readonly ISalesRepository _salesRepository;
    private readonly IProductRepository _productRepository;

    public CreateSalesHandler(IMapper mapper, ISalesRepository salesRepository, IProductRepository productRepository)
    {
        _mapper = mapper;
        _salesRepository = salesRepository;
        _productRepository = productRepository;
    }

    public async Task<CreateSalesResult> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
    {
        var salesEntity = _mapper.Map<Sale>(request);

        // Busca todos os produtos de uma vez
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

        var result = await _salesRepository.CreateAsync(salesEntity, cancellationToken);
        if (result == null)
            throw new Exception("Error creating sale");

        return _mapper.Map<CreateSalesResult>(result);
    }
}