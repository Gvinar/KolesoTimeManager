namespace Koleso.Core.Services
{
    public interface IMappingService
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
