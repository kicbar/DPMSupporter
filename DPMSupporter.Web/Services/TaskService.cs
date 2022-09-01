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
    public class TaskService : ITaskService
    {
        public async Task<TaskDto> SendPostRequest(Guid projectId, TaskDto taskDto)
        {
            TaskDto task = new();
            var content = new StringContent(JsonConvert.SerializeObject(taskDto), Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.PostAsync(ApiData.ApiAddress + $"/api/project/{projectId}/task", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<TaskDto>(apiResponse);
            }
            return task;
        }

        public async Task<List<TaskDto>> SendGetAllRequest(Guid projectId)
        {
            List<TaskDto> taskList = new();
            HttpClientHandler clientHandler = new ();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.GetAsync(ApiData.ApiAddress + $"/api/project/{projectId}/task");
                string apiResponse = await response.Content.ReadAsStringAsync();
                taskList = JsonConvert.DeserializeObject<List<TaskDto>>(apiResponse);
            }
            return taskList;
        }

        public async Task<TaskDto> SendGetRequest(Guid projectId, Guid taskId)
        {
            TaskDto task = new();
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.GetAsync(ApiData.ApiAddress + $"/api/project/{projectId}/task/{taskId}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<TaskDto>(apiResponse);
            }
            return task;
        }

        public async Task<TaskDto> SendPutRequest(TaskDto taskDto)
        {
            TaskDto task = new();
            var content = new StringContent(JsonConvert.SerializeObject(taskDto), Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.PutAsync(ApiData.ApiAddress + $"/api/project/{taskDto.ProjectId}/task/{taskDto.Id}", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<TaskDto>(apiResponse);
            }
            return task;
        }

        public async Task<bool> SendDeleteRequest(Guid projectId, Guid taskId)
        {
            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.DeleteAsync(ApiData.ApiAddress + $"/api/project/{projectId}/task/{taskId}");
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
            return true;
        }
    }
}
