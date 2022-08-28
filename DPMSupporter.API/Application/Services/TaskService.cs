using DPMSupporter.API.Application.DTOs;
using DPMSupporter.API.Application.Services.IServices;
using DPMSupporter.API.Infrastructure.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto> CreateTask(TaskDto taskDto)
        {
            return await ManualTaskMapper(await _taskRepository.AddTask(await ReverseManualTaskMapper(taskDto)));
        }

        public async Task<TaskDto> GetTask(Guid taskId)
        {
            return await ManualTaskMapper(await _taskRepository.GetTask(taskId));
        }

        public async Task<List<TaskDto>> GetAllTask()
        {
            List<TaskDto> projectDtoList = new();
            foreach (Domain.Entities.Task task in await _taskRepository.GetAllTasks())
                projectDtoList.Add(await ManualTaskMapper(task));

            return projectDtoList;
        }

        public async Task<TaskDto> UpdateTask(Guid taskId, TaskDto taskDto)
        {
            return await ManualTaskMapper(await _taskRepository.UpdateTask(await ReverseManualTaskMapper(taskDto, taskId)));
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            return await _taskRepository.DeleteTask(taskId);
        }

        private static async Task<TaskDto> ManualTaskMapper(Domain.Entities.Task task)
        {
            return await Task.Run(() =>
            new TaskDto
            {
                Id = task.Id,
                TaskName = task.TaskName,
                Description = task.Description,
                CreationDate = task.CreationDate,
                IsImplemented = (bool)task.IsImplemented,
                ImplementedDate = task.ImplementedDate!=null ? task.ImplementedDate : null,
                ProjectId = task.ProjectId
            });
        }

        private static async Task<Domain.Entities.Task> ReverseManualTaskMapper(TaskDto taskDto)
        {
            return await Task.Run(() =>
            new Domain.Entities.Task
            {
                Id = taskDto.Id,
                TaskName = taskDto.TaskName,
                Description = taskDto.Description,
                CreationDate = taskDto.CreationDate,
                IsImplemented = taskDto.IsImplemented,
                ImplementedDate = taskDto.ImplementedDate,
                ProjectId = taskDto.ProjectId
            });
        }

        private static async Task<Domain.Entities.Task> ReverseManualTaskMapper(TaskDto taskDto, Guid taskId)
        {
            return await Task.Run(() =>
            new Domain.Entities.Task
            {
                Id = taskId,
                TaskName = taskDto.TaskName,
                Description = taskDto.Description,
                CreationDate = taskDto.CreationDate,
                IsImplemented = taskDto.IsImplemented,
                ImplementedDate = taskDto.ImplementedDate,
                ProjectId = taskDto.ProjectId
            });
        }
    }
}
