namespace Koleso.Persistence.Repositories.TimePriceRule
{
    using Koleso.Persistence.Models;

    public interface ITimePriceRuleRepository
    {
        DbTimePriceRule GetTimePriceRuleById(int timePriceRuleId);
    }
}
