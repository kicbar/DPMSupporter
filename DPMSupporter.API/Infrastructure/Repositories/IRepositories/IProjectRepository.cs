using DPMSupporter.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Infrastructure.Repositories.IRepositories
{
    public interface IProjectRepository
    {
        Task<Project> AddProject(Project project);
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProject(Guid projectId);
        Task<Project> UpdateProject(Project project);
        Task<bool> DeleteProject(Guid projectId);
    }
}