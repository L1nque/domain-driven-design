using Demo.Application.RentalContracting.Commands;
using Demo.Application.RentalContracting.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ardalis.RouteAndBodyModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace Demo.WebApi.Controllers;

[ApiController]
[AllowAnonymous]
[Route("/api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentalsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RentalCreateCommand command)
    {
        var res = await _mediator.Send(command);
        return CreatedAtAction(nameof(Post), new { id = res.Id }, res);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] RentalByIdQuery query)
    {
        var res = await _mediator.Send(query);
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] RentalsListQuery query)
    {
        var res = await _mediator.Send(query);
        return Ok(res);
    }

    [HttpPost("{id:guid}/check-in")]
    public async Task<IActionResult> Post([FromRouteAndBody] RentalCheckInCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("{id:guid}/check-out")]
    public async Task<IActionResult> Post([FromRouteAndBody] RentalCheckOutCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("{id:guid}/close")]
    public async Task<IActionResult> Post([FromRouteAndBody] RentalCloseCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Post([FromRouteAndBody] RentalCancelCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("{id:guid}/extend")]
    public async Task<IActionResult> Post([FromRouteAndBody] RentalExtendCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}