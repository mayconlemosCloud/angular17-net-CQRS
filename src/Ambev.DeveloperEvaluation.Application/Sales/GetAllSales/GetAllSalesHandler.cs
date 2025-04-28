using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Handler for processing GetAllSalesQuery
/// </summary>
public class GetAllSalesHandler : IRequestHandler<GetAllSalesQuery, List<GetAllSalesResult>>
{
    private readonly ISalesRepository _salesRepository;
    private readonly IMapper _mapper;

    public GetAllSalesHandler(ISalesRepository salesRepository, IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllSalesResult>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
    {
        List<Sale> sales = await _salesRepository.GetAllAsync(cancellationToken);
        var salesResult = _mapper.Map<List<GetAllSalesResult>>(sales);
        return salesResult;

    }
}