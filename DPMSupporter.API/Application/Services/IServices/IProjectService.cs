using DPMSupporter.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Application.Services.IServices
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateProject(ProjectWriteDto projectWriteDto);
        Task<List<ProjectDto>> GetAllProjects();
        Task<ProjectDto> GetProject(Guid projectId);
        Task<ProjectDto> UpdateProject(Guid projectId, ProjectWriteDto projectWriteDto);
        Task<bool> DeleteProject(Guid projectId);
    }
}
