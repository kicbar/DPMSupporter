using DPMSupporter.API.Application.Services.IServices;
using DPMSupporter.API.Infrastructure.Repositories.IRepositories;

namespace DPMSupporter.API.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}
