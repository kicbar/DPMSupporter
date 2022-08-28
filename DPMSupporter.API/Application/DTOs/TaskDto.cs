using System;

namespace DPMSupporter.API.Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsImplemented { get; set; }
        public DateTime? ImplementedDate { get; set; }
        public Guid ProjectId { get; set; }
    }
}
