using AutoMapper;
using WebPortfolioApi.Application.Interfaces.Mapper;

namespace WebPortfolioApi.DTO.AutoMapper;

public class MapperService : IMapperT
{
    private readonly IMapper _mapper;

    public MapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        return _mapper.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
    {
        return _mapper.Map<IList<TDestination>>(source);
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        return _mapper.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
        return _mapper.Map<IList<TDestination>>(source);
    }
}
