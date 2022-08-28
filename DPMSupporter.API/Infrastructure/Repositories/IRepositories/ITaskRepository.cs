using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Infrastructure.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        Task<Domain.Entities.Task> AddTask(Domain.Entities.Task task);
        Task<bool> DeleteTask(Guid taskId);
        Task<List<Domain.Entities.Task>> GetAllTasks();
        Task<Domain.Entities.Task> GetTask(Guid taskId);
        Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task);
    }
}
