using DPMSupporter.API.Application.DTOs;
using DPMSupporter.API.Application.Services.IServices;
using DPMSupporter.API.Domain.Entities;
using DPMSupporter.API.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ProjectDto> GetProject(Guid projectId)
        {
            return await ManualProjectMapper(await _projectRepository.GetProject(projectId));
        }

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            List<ProjectDto> projectDtoList = new();
            foreach (Project project in await _projectRepository.GetAllProjects())
            {
                projectDtoList.Add(await ManualProjectMapper(project));
            }
            return projectDtoList;
        }

        private static async Task<ProjectDto> ManualProjectMapper(Project project)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            new ProjectDto
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                CreatedDate = project.CreatedDate
            }); 
        }
    }
}
