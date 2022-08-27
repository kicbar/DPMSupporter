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

        public async Task<ProjectDto> CreateProject(ProjectDto projectDto)
        {
            await ManualProjectMapper(await _projectRepository.AddProject(await ReverseManualProjectMapper(projectDto)));
            return projectDto;
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto projectDto)
        {
            await ManualProjectMapper(await _projectRepository.UpdateProject(await ReverseManualProjectMapper(projectDto)));
            return projectDto;
        }

        public async Task<bool> DeleteProject(Guid projectId)
        {
            return await  _projectRepository.DeleteProject(projectId);
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

        private static async Task<Project> ReverseManualProjectMapper(ProjectDto projectDto)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            new Project
            {
                Id = projectDto.Id,
                ProjectName = projectDto.ProjectName,
                Description = projectDto.Description,
                CreatedDate = projectDto.CreatedDate
            });
        }
    }
}
