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

        public async Task<IActionResult> TaskList([FromRoute] Guid projectId)
        {
            return View(await _taskService.SendGetAllRequest(projectId));
        }

        public async Task<IActionResult> TaskCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaskCreate([FromRoute] Guid projectId, [FromBody] TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _taskService.SendPostRequest(projectId, taskDto);
                return RedirectToAction(nameof(TaskIndex));
            }
            return View(taskDto);
        }

        public IActionResult TaskEdit()
        {
            return View();
        }

        public IActionResult TaskDelete()
        {
            return View();
        }
    }
}
