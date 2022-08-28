using DPMSupporter.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Services.IServices
{
    public interface IProjectService
    {
        Task<ProjectDto> SendPostRequest(ProjectDto projectDto);
        Task<List<ProjectDto>> SendGetAllRequest();
        Task<ProjectDto> SendGetRequest(Guid projectId);
        Task<ProjectDto> SendPutRequest(ProjectDto projectDto);
        Task<bool> SendDeleteRequest(Guid projectId);
    }
}
