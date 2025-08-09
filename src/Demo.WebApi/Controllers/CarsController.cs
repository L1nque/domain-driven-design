using Ardalis.RouteAndBodyModelBinding;
using Demo.Application.FleetManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CarCreateCommand command)
    {
        var res = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = res.Id }, res);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] CarCreateCommand command)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{id:guid}/service/complete")]
    public async Task<IActionResult> Post([FromRouteAndBody] CarCompleteServiceCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}