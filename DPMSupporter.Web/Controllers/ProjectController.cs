﻿using DPMSupporter.Web.Models;
using DPMSupporter.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> ProjectIndex()
        {
            return View(await _projectService.SendGetAllRequest());
        }

        public async Task<IActionResult> ProjectCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProjectCreate(ProjectDto projectDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _projectService.SendPostRequest(projectDto);
                    return RedirectToAction(nameof(ProjectIndex));
            }
            return View(projectDto);
        }
    }
}
