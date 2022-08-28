using DPMSupporter.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Controllers
{
    public class TaskController : Controller
    {
        private IProjectService _projectService;

        public TaskController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> TaskIndex()
        {
            return View(await _projectService.SendGetAllRequest());
        }

        public IActionResult TaskCreate()
        {
            return View();
        }

        public IActionResult TaskList()
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
