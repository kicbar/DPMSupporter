using DPMSupporter.Web.Models;
using DPMSupporter.Web.Services.IServices;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Services
{
    public class ProjectService : IProjectService
    {
        public async Task<List<ProjectDto>> SendGetAllRequest()
        {
            List<ProjectDto> projectList = new();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(ApiData.ApiAddress + "/api/project");
                string apiResponse = await response.Content.ReadAsStringAsync();
                projectList = JsonConvert.DeserializeObject<List<ProjectDto>>(apiResponse);
            }
            return projectList;
        }

        public async Task<ProjectDto> SendPostRequest(ProjectDto projectDto)
        {
            ProjectDto project = new();
            var content = new StringContent(JsonConvert.SerializeObject(projectDto), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.PostAsync(ApiData.ApiAddress + "/api/project", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<ProjectDto>(apiResponse);
            }
            return project;
        }
    }
}
