namespace Koleso.Persistence.Repositories.TimePriceRule
{
    using System;
    using System.Collections.Generic;

    using Koleso.Persistence.Models;

    public interface ITimePriceRuleRepository
    {
        IEnumerable<DbTimePriceRule> GetAllRules();

        DbTimePriceRule GetRuleById(int ruleId);

        IEnumerable<DbTimePriceRule> GetEntitiesByQuery(Func<DbTimePriceRule, bool> query);

        DbTimePriceRule CreateOrUpdateEntity(DbTimePriceRule rule);

        void DeleteEntity(int ruleId);
    }
}
