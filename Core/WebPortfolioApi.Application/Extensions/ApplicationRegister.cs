﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebPortfolioApi.Application.ServiceManagers.Abstracts;
using WebPortfolioApi.Application.ServiceManagers.Concretes;

namespace WebPortfolioApi.Application.Extensions
{
    public static class ApplicationRegister
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
