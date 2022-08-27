using System;
using System.ComponentModel;

namespace DPMSupporter.API.Domain.Entities
{
    [AttributeUsage(AttributeTargets.All)]
    public class Task : Attribute
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        [DefaultValue("getutcdate()")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [DefaultValue(false)]
        public bool? IsImplemented { get; set; } = false;
        public DateTime? ImplementedDate { get; set; }

        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
