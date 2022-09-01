using DPMSupporter.API.Application.DTOs;
using DPMSupporter.API.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Controllers
{
    [ApiController]
    [Route("api/project/{projectId}/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<TaskDto> Post([FromRoute] Guid projectId, [FromBody] TaskWriteDto taskWriteDto)
        {
            return await _taskService.CreateTask(projectId, taskWriteDto);
        }

        [HttpGet]
        public async Task<List<TaskDto>> GetAll([FromRoute] Guid projectId)
        {
            return await _taskService.GetAllTask(projectId);
        }

        [HttpGet("{taskid}")]
        public async Task<TaskDto> Get([FromRoute] Guid projectId, [FromRoute] Guid taskId)
        {
            return await _taskService.GetTask(projectId, taskId);
        }

        [HttpPut("{taskId}")]
        public async Task<TaskDto> Put([FromRoute] Guid projectId, [FromRoute] Guid taskId, [FromBody] TaskDto taskDto)
        {
            return await _taskService.UpdateTask(projectId, taskId, taskDto);
        }

        [HttpDelete("{taskId}")]
        public async Task<bool> Delete([FromRoute] Guid projectId, [FromRoute] Guid taskId)
        {
            return await _taskService.DeleteTask(projectId, taskId);
        }
    }
}
