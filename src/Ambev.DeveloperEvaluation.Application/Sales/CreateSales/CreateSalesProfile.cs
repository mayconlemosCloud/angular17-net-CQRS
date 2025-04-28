using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

/// <summary>
/// Profile for mapping CreateSales entities
/// </summary>
public class CreateSalesProfile : Profile
{
    public CreateSalesProfile()
    {
        CreateMap<CreateSalesCommand, CreateSalesResult>();
        CreateMap<Sale, CreateSalesResult>()
            .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Id));
        CreateMap<CreateSalesCommand, Sale>();
        CreateMap<CreateSalesItemCommand, SaleItem>();
    }
}