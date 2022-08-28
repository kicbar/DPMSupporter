using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Infrastructure.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        Task<Domain.Entities.Task> AddTask(Domain.Entities.Task task);
        Task<List<Domain.Entities.Task>> GetAllTasks(Guid projectId);
        Task<Domain.Entities.Task> GetTask(Guid projectId, Guid taskId);
        Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task);
        Task<bool> DeleteTask(Guid projectId, Guid taskId);
    }
}
