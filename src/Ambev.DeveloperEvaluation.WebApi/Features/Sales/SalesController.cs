using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;
using Microsoft.AspNetCore.Authorization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sales operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSalesRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSalesCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSalesResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSalesResponse>(response)
        });
    }

    [HttpGet("{saleId}")]
    public async Task<IActionResult> GetSale([FromRoute] Guid saleId, CancellationToken cancellationToken)
    {
        var request = new GetSalesRequest { SaleId = saleId };
        var validator = new GetSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = new GetSalesCommand { SaleId = request.SaleId };
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSalesResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSalesResponse>(response)
        });
    }

    [HttpDelete("{saleId}")]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid saleId, CancellationToken cancellationToken)
    {
        var request = new DeleteSalesRequest { SaleId = saleId };
        var validator = new DeleteSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = new DeleteSalesCommand { SaleId = request.SaleId };
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale deleted successfully"
        });
    }

    [HttpGet]
    [Route("api/sales")]
    public async Task<IActionResult> GetAllSales(CancellationToken cancellationToken)
    {
        var query = new GetAllSalesQuery();
        var response = await _mediator.Send(query, cancellationToken);

        return Ok(new ApiResponseWithData<List<GetAllSalesResponse>>
        {
            Success = true,
            Message = "Sales retrieved successfully",
            Data = _mapper.Map<List<GetAllSalesResponse>>(response)
        });
    }

    [HttpPut("{saleId}")]
    public async Task<IActionResult> UpdateSale([FromRoute] Guid saleId, [FromBody] UpdateSalesRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateSalesCommand>(request);
        command.Id = saleId;

        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale updated successfully"
        });
    }
}