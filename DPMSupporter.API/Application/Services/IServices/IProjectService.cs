using DPMSupporter.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Application.Services.IServices
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateProject(ProjectDto projectDto);
        Task<List<ProjectDto>> GetAllProjects();
        Task<ProjectDto> GetProject(Guid projectId);
        Task<ProjectDto> UpdateProject(ProjectDto projectDto);
        Task<bool> DeleteProject(Guid projectId);
    }
}
