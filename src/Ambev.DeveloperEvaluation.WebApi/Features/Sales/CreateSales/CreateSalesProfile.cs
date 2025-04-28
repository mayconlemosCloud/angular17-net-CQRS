using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Profile for mapping between Application and API CreateSales responses
/// </summary>
public class CreateSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSales feature
    /// </summary>
    public CreateSalesProfile()
    {
        CreateMap<CreateSalesRequest, CreateSalesCommand>();
        CreateMap<CreateSalesItemRequest, CreateSalesItemCommand>(); // Added mapping for Items
        CreateMap<CreateSalesResult, CreateSalesResponse>();
    }
}