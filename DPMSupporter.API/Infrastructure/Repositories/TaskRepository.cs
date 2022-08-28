using DPMSupporter.API.Infrastructure.Data;
using DPMSupporter.API.Infrastructure.Repositories.IRepositories;

namespace DPMSupporter.API.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DPMSupporterDbContext _DPMSupporterDbContext;

        public TaskRepository(DPMSupporterDbContext DPMSupporterDbContext)
        {
            _DPMSupporterDbContext = DPMSupporterDbContext;
        }
    }
}
