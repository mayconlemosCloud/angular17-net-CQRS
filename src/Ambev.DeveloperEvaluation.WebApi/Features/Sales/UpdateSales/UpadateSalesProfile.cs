using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

/// <summary>
/// Profile for mapping between Application and API UpdateSales responses
/// </summary>
public class UpdateSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSales feature
    /// </summary>
    public UpdateSalesProfile()
    {
        CreateMap<UpdateSalesRequest, UpdateSalesCommand>();
        CreateMap<UpdateSalesItemRequest, UpdateSalesItemCommand>(); // Added mapping for Items
        CreateMap<UpdateSalesResult, UpdateSalesResponse>();
    }
}