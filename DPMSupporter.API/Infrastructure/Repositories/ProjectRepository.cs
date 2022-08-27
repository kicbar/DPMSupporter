using DPMSupporter.API.Domain.Entities;
using DPMSupporter.API.Infrastructure.Data;
using DPMSupporter.API.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPMSupporter.API.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DPMSupporterDbContext _DPMSupporterDbContext;

        public ProjectRepository(DPMSupporterDbContext DPMSupporterDbContext)
        {
            _DPMSupporterDbContext = DPMSupporterDbContext;
        }

        public Guid AddProject(Project project)
        {
            return Guid.NewGuid();
        }
        public Project GetProject(Guid projectGuid)
        {
            return new Project();
        }

        public List<Project> GetAllProjects()
        {
            return new List<Project>();
        }

        public Project UpdateProject(Project project)
        {
            return new Project();
        }

        public bool DeleteProject(Project project)
        {
            return true;
        }
    }
}
