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

        public async Task<Project> AddProject(Project project)
        {
            var createdProject = await _DPMSupporterDbContext.Projects.AddAsync(project);
            await _DPMSupporterDbContext.SaveChangesAsync();
            return createdProject.Entity;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _DPMSupporterDbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProject(Guid projectId)
        {
            return await _DPMSupporterDbContext.Projects.Where(p => p.Id == projectId).FirstOrDefaultAsync();
        }

        public async Task<Project> UpdateProject(Project project)
        {
            var projectExist = await _DPMSupporterDbContext.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (projectExist != null)
            {
                var updatedProject = _DPMSupporterDbContext.Projects.Update(project);
                await _DPMSupporterDbContext.SaveChangesAsync();
                return updatedProject.Entity;
            }
            throw new Exception("Updated not executed.");
        }

        public async Task<bool> DeleteProject(Guid projectId)
        {
            try
            {//
                var projectExist = await _DPMSupporterDbContext.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
                if (projectExist != null)
                {
                    _DPMSupporterDbContext.Projects.Remove(projectExist);
                    await _DPMSupporterDbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Error occured: {exc.Message}");
                return false;
            }
        }
    }
}
