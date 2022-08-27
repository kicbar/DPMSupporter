using DPMSupporter.API.Application.DTOs;
using DPMSupporter.API.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.API.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<List<ProjectDto>> GetAll()
        {
            return await _projectService.GetAllProjects();
        }

        [HttpGet("{projectId}")]
        public async Task<ProjectDto> Get(Guid projectId)
        {
            return await _projectService.GetProject(projectId);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
