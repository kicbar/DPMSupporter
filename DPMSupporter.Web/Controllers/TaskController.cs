using DPMSupporter.Web.Models;
using DPMSupporter.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;

        public TaskController(IProjectService projectService, ITaskService taskService)
        {
            _taskService = taskService;
            _projectService = projectService;
        }

        public async Task<IActionResult> TaskIndex()
        {
            return View(await _projectService.SendGetAllRequest());
        }

        public async Task<IActionResult> TaskList(Guid projectId)
        {
            ViewData["projectId"] = projectId;
            return View(await _taskService.SendGetAllRequest(projectId));
        }

        public async Task<IActionResult> TaskCreate(Guid projectId)
        {
            ViewData["projectId"] = projectId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaskCreate(Guid projectId, TaskDto taskDto)
        {
            var response = await _taskService.SendPostRequest(projectId, taskDto);
            return RedirectToAction(nameof(TaskList), new { projectId });
        }

        public async Task<IActionResult> TaskEdit(Guid projectId, Guid taskId)
        {
            var response = await _taskService.SendGetRequest(projectId, taskId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> TaskEdit(Guid projectId, Guid Id, TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _taskService.SendPutRequest(taskDto);
                return RedirectToAction(nameof(TaskList), new { projectId });
            }
            return View(taskDto);
        }

        public async Task<IActionResult> TaskDelete(Guid projectId, Guid taskId)
        {
            var response = await _taskService.SendGetRequest(projectId, taskId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> TaskDelete(TaskDto taskDto)
        {
            var response = await _taskService.SendDeleteRequest(taskDto.ProjectId, taskDto.Id);
            return RedirectToAction(nameof(TaskList), new { taskDto.ProjectId });
        }
    }
}
