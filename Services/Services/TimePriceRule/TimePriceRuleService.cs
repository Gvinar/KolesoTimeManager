namespace Services.Services.TimePriceRule
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Koleso.Core.Models.TimePriceRule;
    using Koleso.Core.Services;
    using Koleso.Core.Services.TimePriceRule;
    using Koleso.Persistence.Models;
    using Koleso.Persistence.Repositories.TimePriceRule;

    public class TimePriceRuleService : ITimePriceRuleService
    {
        private readonly ITimePriceRuleRepository ruleRepository;

        private readonly IMappingService mappingService;

        public TimePriceRuleService(ITimePriceRuleRepository ruleRepository, IMappingService mappingService)
        {
            this.ruleRepository = ruleRepository;
            this.mappingService = mappingService;
        }

        public async Task<ITimePriceRule> GetRuleById(int ruleId)
        {
            var dbRule = this.ruleRepository.GetRuleById(ruleId);
            var rule = this.mappingService.Map<DbTimePriceRule, ITimePriceRule>(dbRule);
            var source = new TaskCompletionSource<ITimePriceRule>();
            source.SetResult(rule);
            return await source.Task;
        }

        public Task<List<ITimePriceRule>> GetAllRules()
        {
            var task = Task.Run(() =>
            {
                var dbrules = this.ruleRepository.GetAllRules();
                var rules = dbrules.Select(r => this.mappingService.Map<DbTimePriceRule, ITimePriceRule>(r)).ToList();
                return rules;
            });

            return task;
        }
    }
}