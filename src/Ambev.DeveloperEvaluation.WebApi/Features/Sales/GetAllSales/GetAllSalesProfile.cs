using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<Sale, GetAllSalesResult>();
        CreateMap<GetAllSalesResult, GetAllSalesResponse>();
    }
}