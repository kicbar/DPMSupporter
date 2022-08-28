using DPMSupporter.API.Infrastructure.Data;
using DPMSupporter.API.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPMSupporter.API.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DPMSupporterDbContext _DPMSupporterDbContext;

        public TaskRepository(DPMSupporterDbContext DPMSupporterDbContext)
        {
            _DPMSupporterDbContext = DPMSupporterDbContext;
        }

        public async Task<Domain.Entities.Task> AddTask(Domain.Entities.Task task)
        {
            var createdTask = await _DPMSupporterDbContext.Tasks.AddAsync(task);
            await _DPMSupporterDbContext.SaveChangesAsync();
            return createdTask.Entity;
        }

        public async Task<List<Domain.Entities.Task>> GetAllTasks()
        {
            return await _DPMSupporterDbContext.Tasks.ToListAsync();
        }

        public async Task<Domain.Entities.Task> GetTask(Guid taskId)
        {
            return await _DPMSupporterDbContext.Tasks.Where(t => t.Id == taskId).FirstOrDefaultAsync();
        }

        public async Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task)
        {
            var taskExist = await _DPMSupporterDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);
            if (taskExist != null)
            {
                var updatedTask = _DPMSupporterDbContext.Tasks.Update(task);
                await _DPMSupporterDbContext.SaveChangesAsync();
                return updatedTask.Entity;
            }
            throw new Exception("Updated not executed.");
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            try
            {
                var taskExist = await _DPMSupporterDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
                if (taskExist != null)
                {
                    _DPMSupporterDbContext.Tasks.Remove(taskExist);
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
