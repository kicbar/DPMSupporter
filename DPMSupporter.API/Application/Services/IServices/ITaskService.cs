using DPMSupporter.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Application.Services.IServices
{
    public interface ITaskService
    {
        Task<TaskDto> CreateTask(TaskDto taskDto);
        Task<bool> DeleteTask(Guid taskId);
        Task<List<TaskDto>> GetAllTask();
        Task<TaskDto> GetTask(Guid taskId);
        Task<TaskDto> UpdateTask(Guid taskId, TaskDto taskDto);
    }
}
