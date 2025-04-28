using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;

/// <summary>
/// Profile for mapping between Application and API DeleteSales responses
/// </summary>
public class DeleteSalesProfile : Profile
{
    public DeleteSalesProfile()
    {
        CreateMap<DeleteSalesRequest, DeleteSalesCommand>();
    }
}