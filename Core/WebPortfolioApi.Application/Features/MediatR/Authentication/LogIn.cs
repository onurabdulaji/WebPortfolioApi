using MediatR;
using WebPortfolioApi.Application.Interfaces.IRepositories.Authentication;
using WebPortfolioApi.Application.ServiceManagers.Abstracts;

namespace WebPortfolioApi.Application.Features.MediatR.Authentication;

public static class LogIn
{
    public class Command : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    internal sealed class Handler : IRequestHandler<Command, Guid>
    {
        private readonly IAuthenticationService _authenticationService;

        public Handler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.LogIn(request.Email, request.Password);

            return user.Id;
        }
    }
}
