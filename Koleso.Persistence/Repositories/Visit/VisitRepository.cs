using System;

namespace Koleso.Persistence.Repositories.Visit
{
    using System.Collections.Generic;
    using System.Linq;

    using Koleso.Database;
    using Koleso.Persistence.Models;

    public class VisitRepository : IVisitRepository
    {
        public IEnumerable<DbVisit> GetAllVisits()
        {
            IEnumerable<DbVisit> collection;
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                collection = session.Query<DbVisit>().ToList();
            }

            return collection;
        }

        public DbVisit GetVisitById(int visitId)
        {
            DbVisit entity;
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                entity = session.Load<DbVisit>(visitId);
            }

            return entity;
        }

        public IEnumerable<DbVisit> GetEntitiesByQuery(Func<DbVisit, bool> query)
        {
            IEnumerable<DbVisit> collection;
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                collection = session.Query<DbVisit>().Where(query).ToList();
            }

            return collection;
        }

        public DbVisit CreateOrUpdateEntity(DbVisit visit)
        {
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                session.Store(visit);
                session.SaveChanges();
            }

            return visit;
        }

        public void DeleteEntity(int visitId)
        {
            using (var session = DocumentStoreConnection.Current.OpenSession())
            {
                var entity = session.Load<DbVisit>(visitId);
                session.Delete(entity);
                session.SaveChanges();
            }
        }
    }
}
