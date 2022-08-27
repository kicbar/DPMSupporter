using DPMSupporter.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPMSupporter.Web.Services.IServices
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> SendGetAllRequest();
        Task<ProjectDto> SendPostRequest(ProjectDto projectDto);
    }
}
