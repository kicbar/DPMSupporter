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

        public async Task<ProjectDto> CreateProject(ProjectWriteDto projectWriteDto)
        {
            return await ManualProjectMapper(await _projectRepository.AddProject(await ReverseManualProjectMapper(projectWriteDto)));
        }

        public async Task<ProjectDto> GetProject(Guid projectId)
        {
            return await ManualProjectMapper(await _projectRepository.GetProject(projectId));
        }

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            List<ProjectDto> projectDtoList = new();
            foreach (Project project in await _projectRepository.GetAllProjects())
                projectDtoList.Add(await ManualProjectMapper(project));

            return projectDtoList;
        }

        public async Task<ProjectDto> UpdateProject(Guid projectId, ProjectWriteDto projectWriteDto)
        {
            return await ManualProjectMapper(await _projectRepository.UpdateProject(await ReverseManualProjectMapper(projectWriteDto, projectId)));
        }

        public async Task<bool> DeleteProject(Guid projectId)
        {
            return await _projectRepository.DeleteProject(projectId);
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

        private static async Task<Project> ReverseManualProjectMapper(ProjectWriteDto projectWriteDto)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            new Project
            {
                ProjectName = projectWriteDto.ProjectName,
                Description = projectWriteDto.Description,
                ProjectShortName = projectWriteDto.ProjectShortName
            });
        }

        private static async Task<Project> ReverseManualProjectMapper(ProjectWriteDto projectWriteDto, Guid projectId)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            new Project
            {
                Id = projectId,
                ProjectName = projectWriteDto.ProjectName,
                Description = projectWriteDto.Description,
                ProjectShortName = projectWriteDto.ProjectShortName
            });
        }
    }
}
