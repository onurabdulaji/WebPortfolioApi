using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebPortfolioApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpPost("login")]
    //public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginCommandRequest request)
    //{
    //    if (request == null)
    //    {
    //        return BadRequest("Invalid login request.");
    //    }

    //    var response = await _mediator.Send(request);

    //    return Ok(response);
    //}
}
