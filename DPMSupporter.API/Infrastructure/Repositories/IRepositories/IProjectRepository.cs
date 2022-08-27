using DPMSupporter.API.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DPMSupporter.API.Infrastructure.Repositories.IRepositories
{
    public interface IProjectRepository
    {
        Guid AddProject(Project project);
        bool DeleteProject(Project project);
        List<Project> GetAllProjects();
        Project GetProject(Guid projectGuid);
        Project UpdateProject(Project project);
    }
}