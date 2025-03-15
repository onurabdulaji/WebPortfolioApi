using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebPortfolioApi.Application.Features.MediatR.Authentication;

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
    [HttpPost("login")]
    public async Task<IActionResult> LogIn([FromBody] LogIn.Command command)
    {
        if (command == null || string.IsNullOrEmpty(command.Email) || string.IsNullOrEmpty(command.Password))
        {
            return BadRequest("Invalid login request.");
        }
        try
        {
            var userId = await _mediator.Send(command);
            return Ok(new { UserId = userId }); 
        }
        catch (Exception ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
    }

}
