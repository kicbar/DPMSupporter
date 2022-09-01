using DPMSupporter.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Application.Services.IServices
{
    public interface ITaskService
    {
        Task<TaskDto> CreateTask(Guid projectId, TaskWriteDto taskWriteDto);
        Task<bool> DeleteTask(Guid projectId, Guid taskId);
        Task<List<TaskDto>> GetAllTask(Guid projectId);
        Task<TaskDto> GetTask(Guid projectId, Guid taskId);
        Task<TaskDto> UpdateTask(Guid projectId, Guid taskId, TaskDto taskDto);
    }
}
