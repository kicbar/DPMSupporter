using DPMSupporter.Web.Models;
using DPMSupporter.Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Services
{
    public class TaskService : ITaskService
    {
        public async Task<List<TaskDto>> SendGetAllRequest(Guid projectId)
        {
            List<TaskDto> taskList = new();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var httpClient = new HttpClient(clientHandler))
            {
                using var response = await httpClient.GetAsync(ApiData.ApiAddress + $"/api/project/{projectId}/task");
                string apiResponse = await response.Content.ReadAsStringAsync();
                taskList = JsonConvert.DeserializeObject<List<TaskDto>>(apiResponse);
            }
            return taskList;
        }

    }
}
