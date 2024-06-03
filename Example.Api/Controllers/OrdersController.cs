using Example.Application.Commands.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateCommand orderCreateCommand)
    {
        var response = await mediator.Send(orderCreateCommand);

        return Ok(response);
    }
}