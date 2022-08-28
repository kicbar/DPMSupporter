using DPMSupporter.Web.Models;
using DPMSupporter.Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Services
{
    public class ProjectService : IProjectService
    {
        public async Task<ProjectDto> SendPostRequest(ProjectDto projectDto)
        {
            ProjectDto project = new();
            var content = new StringContent(JsonConvert.SerializeObject(projectDto), Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.PostAsync(ApiData.ApiAddress + "/api/project", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<ProjectDto>(apiResponse);
            }
            return project;
        }

        public async Task<List<ProjectDto>> SendGetAllRequest()
        {
            List<ProjectDto> projectList = new();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.GetAsync(ApiData.ApiAddress + "/api/project");
                string apiResponse = await response.Content.ReadAsStringAsync();
                projectList = JsonConvert.DeserializeObject<List<ProjectDto>>(apiResponse);
            }
            return projectList;
        }

        public async Task<ProjectDto> SendGetRequest(Guid projectId)
        {
            ProjectDto project = new();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.GetAsync(ApiData.ApiAddress + $"/api/project/{projectId}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<ProjectDto>(apiResponse);
            }
            return project;
        }

        public async Task<ProjectDto> SendPutRequest(ProjectDto projectDto)
        {
            ProjectDto project = new();
            var content = new StringContent(JsonConvert.SerializeObject(projectDto), Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.PutAsync(ApiData.ApiAddress + $"/api/project/{projectDto.Id}", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<ProjectDto>(apiResponse);
            }
            return project;
        }

        public async Task<bool> SendDeleteRequest(Guid projectId)
        {
            ProjectDto project = new();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.GetAsync(ApiData.ApiAddress + $"/api/project/{projectId}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                //project = JsonConvert.DeserializeObject<ProjectDto>(apiResponse);
            }
            return true;
        }
    }
}
