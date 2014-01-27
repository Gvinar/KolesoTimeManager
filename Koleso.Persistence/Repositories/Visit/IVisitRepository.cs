namespace Koleso.Persistence.Repositories.Visit
{
    using System;
    using System.Collections.Generic;

    using Koleso.Persistence.Models;

    public interface IVisitRepository
    {
        IEnumerable<DbVisit> GetAllVisits();

        DbVisit GetVisitById(int visitId);

        IEnumerable<DbVisit> GetEntitiesByQuery(Func<DbVisit, bool> query);

        DbVisit CreateOrUpdateEntity(DbVisit visit);

        void DeleteEntity(int visitId);
    }
}
