using DPMSupporter.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Services.IServices
{
    public interface ITaskService
    {
        Task<List<TaskDto>> SendGetAllRequest(Guid projectId);
    }
}