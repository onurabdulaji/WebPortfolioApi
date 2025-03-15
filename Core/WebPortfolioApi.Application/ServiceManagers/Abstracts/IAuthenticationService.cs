using WebPortfolioApi.Domain.Entities;

namespace WebPortfolioApi.Application.ServiceManagers.Abstracts
{
    public interface IAuthenticationService
    {
        Task<User> LogIn(string email, string password);
        //Task ValidateLogin(LoginCommandRequest  request);
        Task<IList<string>> GetLoginRoles(string email, string password);

    }
}
