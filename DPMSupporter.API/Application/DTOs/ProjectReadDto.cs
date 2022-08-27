using System;

namespace DPMSupporter.API.Application.DTOs
{
    public class ProjectReadDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
