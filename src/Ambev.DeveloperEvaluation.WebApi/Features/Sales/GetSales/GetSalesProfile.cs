using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

/// <summary>
/// Profile for mapping between Application and API GetSales responses
/// </summary>
public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<GetSalesRequest, GetSalesCommand>();
        CreateMap<GetSalesResult, GetSalesResponse>();
    }
}