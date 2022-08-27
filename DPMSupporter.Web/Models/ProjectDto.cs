using System;

namespace DPMSupporter.Web.Models
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
