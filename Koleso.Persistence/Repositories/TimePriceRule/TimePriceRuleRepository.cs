using System;

namespace Koleso.Persistence.Repositories.TimePriceRule
{
    using System.Collections.Generic;
    using System.Linq;

    using Koleso.Database;
    using Koleso.Persistence.Models;

    public class TimePriceRuleRepository : ITimePriceRuleRepository
    {
        public IEnumerable<DbTimePriceRule> GetAllRules()
        {
            IEnumerable<DbTimePriceRule> collection;
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                collection = session.Query<DbTimePriceRule>().ToList();
            }

            return collection;
        }

        public DbTimePriceRule GetRuleById(int ruleId)
        {
            DbTimePriceRule entity;
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                entity = session.Load<DbTimePriceRule>(ruleId);
            }

            return entity;
        }

        public IEnumerable<DbTimePriceRule> GetEntitiesByQuery(Func<DbTimePriceRule, bool> query)
        {
            IEnumerable<DbTimePriceRule> collection;
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                collection = session.Query<DbTimePriceRule>().Where(query).ToList();
            }

            return collection;
        }

        public DbTimePriceRule CreateOrUpdateEntity(DbTimePriceRule rule)
        {
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                session.Store(rule);
                session.SaveChanges();
            }

            return rule;
        }

        public void DeleteEntity(int ruleId)
        {
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                var entity = session.Load<DbTimePriceRule>(ruleId);
                session.Delete(entity);
                session.SaveChanges();
            }
        }
    }
}
