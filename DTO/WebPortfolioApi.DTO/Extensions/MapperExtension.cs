using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebPortfolioApi.Application.Interfaces.Mapper;
using WebPortfolioApi.DTO.AutoMapper;

namespace WebPortfolioApi.DTO.Extensions;

public static class MapperExtension 
{
    public static void AddDTOLayer(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
        });

        IMapper mapper = config.CreateMapper();
        services.AddSingleton(mapper);
        services.AddScoped<IMapperT, MapperService>();
    }
}
