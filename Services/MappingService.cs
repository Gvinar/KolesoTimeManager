namespace Services
{
    using Koleso.Core.Services;

    public class MappingService : IMappingService
    {
        public MappingService()
        {
            MapperConfig.MapperConfig.Configure();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapped = AutoMapper.Mapper.Map<TDestination>(source);
            return mapped;
        }
    }
}
