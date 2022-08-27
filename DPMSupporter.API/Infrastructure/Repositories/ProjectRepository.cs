using DPMSupporter.API.Domain.Entities;
using DPMSupporter.API.Infrastructure.Data;
using DPMSupporter.API.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
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

        public Task<Project> AddProject(Project project)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Project>> GetAllProjects()
        {
            return await _DPMSupporterDbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProject(Guid projectId)
        {
            return await _DPMSupporterDbContext.Projects.Where(p => p.Id == projectId).FirstOrDefaultAsync();
        }

        public Task<Project> UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
