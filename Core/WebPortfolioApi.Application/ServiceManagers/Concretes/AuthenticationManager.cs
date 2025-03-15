using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebPortfolioApi.Application.ServiceManagers.Abstracts;
using WebPortfolioApi.Domain.Entities;

namespace WebPortfolioApi.Application.ServiceManagers.Concretes
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        //private readonly IValidator<LoginCommandRequest> _validator;
        private readonly ILogger<AuthenticationManager> _logger;


        public AuthenticationManager(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<AuthenticationManager> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IList<string>> GetLoginRoles(string email, string password)
        {
            var user = await LogIn(email, password);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<User> LogIn(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning("Kullanıcı bulunamadı: {Email}", email);
                throw new Exception("Kullanıcı bulunamadı");
            }
            ;

            var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (!signInResult.Succeeded)
            {
                _logger.LogWarning("Geçersiz şifre giriş denemesi: {Email}", email);
                throw new Exception("Geçersiz şifre");
            }

            _logger.LogInformation("Başarıyla giriş yapıldı: {Email}", email);
            return user;

        }
        //public async Task ValidateLogin(LoginCommandRequest request)
        //{
        //    var validationResult = await _validator.ValidateAsync(request);
        //    if (!validationResult.IsValid)
        //    {
        //        _logger.LogWarning("Giriş doğrulama hatası: {Email}", request.Email);
        //        throw new ValidationException(validationResult.Errors);
        //    }
        //}
    }
}