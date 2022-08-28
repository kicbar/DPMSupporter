using DPMSupporter.API.Application.DTOs;
using DPMSupporter.API.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<TaskDto> Post([FromBody] TaskDto taskDto)
        {
            return await _taskService.CreateTask(taskDto);
        }

        [HttpGet]
        public async Task<List<TaskDto>> GetAll()
        {
            return await _taskService.GetAllTask();
        }

        [HttpGet("{taskid}")]
        public async Task<TaskDto> Get([FromRoute] Guid taskId)
        {
            return await _taskService.GetTask(taskId);
        }

        [HttpPut("{taskId}")]
        public async Task<TaskDto> Put([FromRoute] Guid taskId, [FromBody] TaskDto taskDto)
        {
            return await _taskService.UpdateTask(taskId, taskDto);
        }

        [HttpDelete("{taskId}")]
        public async Task<bool> Delete([FromRoute] Guid taskId)
        {
            return await _taskService.DeleteTask(taskId);
        }
    }
}
