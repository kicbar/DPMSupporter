using DPMSupporter.Web.Models;
using DPMSupporter.Web.Services.IServices;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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
    }
}
