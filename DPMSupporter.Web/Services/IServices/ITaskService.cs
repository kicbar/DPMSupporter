using DPMSupporter.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Services.IServices
{
    public interface ITaskService
    {
        Task<TaskDto> SendPostRequest(Guid projectId, TaskDto taskDto);
        Task<List<TaskDto>> SendGetAllRequest(Guid projectId);
        Task<TaskDto> SendGetRequest(Guid projectId, Guid taskId);
        Task<TaskDto> SendPutRequest(TaskDto taskDto);
        Task<bool> SendDeleteRequest(Guid projectId, Guid taskId);
    }
}