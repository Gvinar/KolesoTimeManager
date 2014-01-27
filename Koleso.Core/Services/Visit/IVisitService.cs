namespace Koleso.Core.Services.Visit
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Koleso.Core.Models.Visit;

    public interface IVisitService
    {
        Task<IVisit> GetVisitById(int visitId);

        Task<List<IVisit>> GetAllVisits();
    }
}
