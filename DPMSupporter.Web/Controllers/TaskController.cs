using DPMSupporter.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Controllers
{
    public class TaskController : Controller
    {
        private IProjectService _projectService;
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
            return View(await _taskService.SendGetAllRequest(projectId));
        }

        public IActionResult TaskCreate()
        {
            return View();
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
