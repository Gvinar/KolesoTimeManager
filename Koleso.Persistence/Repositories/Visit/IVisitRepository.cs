namespace Koleso.Persistence.Repositories.Visit
{
    using Koleso.Persistence.Models;

    public interface IVisitRepository
    {
        DbVisit GetVisitById(int visitId);
    }
}
