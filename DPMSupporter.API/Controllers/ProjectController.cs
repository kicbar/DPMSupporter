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
        public async Task<ProjectDto> Post([FromBody] ProjectDto productDto)
        {
            return await _projectService.CreateProject(productDto);
        }

        [HttpGet]
        public async Task<List<ProjectDto>> GetAll()
        {
            return await _projectService.GetAllProjects();
        }

        [HttpGet("{projectId}")]
        public async Task<ProjectDto> Get([FromForm] Guid projectId)
        {
            return await _projectService.GetProject(projectId);
        }

        [HttpPut]
        public async Task<ProjectDto> Put([FromBody] ProjectDto productDto)
        {
            return await _projectService.UpdateProject(productDto);
        }

        [HttpDelete]
        public async Task<bool> Delete([FromBody] ProjectDto productDto)
        {
            return await _projectService.DeleteProject(productDto);
        }
    }
}
