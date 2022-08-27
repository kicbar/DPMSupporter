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

        [HttpPost]
        public async Task<ProjectDto> Post([FromBody] ProjectWriteDto projectWriteDto)
        {
            return await _projectService.CreateProject(projectWriteDto);
        }

        [HttpGet]
        public async Task<List<ProjectDto>> GetAll()
        {
            return await _projectService.GetAllProjects();
        }

        [HttpGet("{projectId}")]
        public async Task<ProjectDto> Get([FromRoute] Guid projectId)
        {
            return await _projectService.GetProject(projectId);
        }

        [HttpPut("{projectId}")]
        public async Task<ProjectDto> Put([FromRoute] Guid projectId, [FromBody] ProjectWriteDto projectWriteDto)
        {
            return await _projectService.UpdateProject(projectId, projectWriteDto);
        }

        [HttpDelete("{projectId}")]
        public async Task<bool> Delete([FromRoute] Guid projectId)
        {
            return await _projectService.DeleteProject(projectId);
        }
    }
}
