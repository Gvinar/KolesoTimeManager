namespace Koleso.Core.Services.TimePriceRule
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Koleso.Core.Models.TimePriceRule;

    public interface ITimePriceRuleService
    {
        Task<ITimePriceRule> GetRuleById(int ruleId);

        Task<List<ITimePriceRule>> GetAllRules();
    }
}
