namespace Services.MapperConfig
{
    using AutoMapper;

    using Koleso.Core.Models.TimePriceRule;
    using Koleso.Core.Models.Visit;
    using Koleso.Persistence.Models;

    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<DbVisit, IVisit>();
            Mapper.CreateMap<DbTimePriceRule, ITimePriceRule>();
        }
    }
}
