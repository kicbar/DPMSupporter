using DPMSupporter.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Application.Services.IServices
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllProjects();
        Task<ProjectDto> GetProject(Guid projectId);
    }
}
