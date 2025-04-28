using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

/// <summary>
/// Profile for mapping UpdateSales entities
/// </summary>
public class UpdateSalesProfile : Profile
{
    public UpdateSalesProfile()
    {
        CreateMap<UpdateSalesCommand, UpdateSalesResult>();
        CreateMap<Sale, UpdateSalesResult>();
        CreateMap<UpdateSalesCommand, Sale>();
        CreateMap<UpdateSalesItemCommand, SaleItem>();
    }
}