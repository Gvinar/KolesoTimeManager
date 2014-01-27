namespace Services.Services.Visit
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Koleso.Core.Models.Visit;
    using Koleso.Core.Services;
    using Koleso.Core.Services.Visit;
    using Koleso.Persistence.Models;
    using Koleso.Persistence.Repositories.Visit;

    public class VisitService : IVisitService
    {
        private readonly IVisitRepository visitRepository;

        private readonly IMappingService mappingService;

        public VisitService(IVisitRepository visitRepository, IMappingService mappingService)
        {
            this.visitRepository = visitRepository;
            this.mappingService = mappingService;
        }

        public async Task<IVisit> GetVisitById(int visitId)
        {
            var dbVisit = this.visitRepository.GetVisitById(visitId);
            var visit = this.mappingService.Map<DbVisit, IVisit>(dbVisit);
            var source = new TaskCompletionSource<IVisit>();
            source.SetResult(visit);
            return await source.Task;
        }

        public Task<List<IVisit>> GetAllVisits()
        {
            var task = Task.Run(() =>
            {
                var dbvisits = this.visitRepository.GetAllVisits();
                var visits = dbvisits.Select(v => this.mappingService.Map<DbVisit, IVisit>(v)).ToList();
                return visits;
            });

            return task;
        }
    }
}
