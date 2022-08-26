using System;

namespace DPMSupporter.API.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsImplemented { get; set; } = false;
        public DateTime ImplementedDate { get; set; }

        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
