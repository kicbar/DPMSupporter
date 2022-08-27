using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DPMSupporter.API.Domain.Entities
{
    [AttributeUsage(AttributeTargets.All)]
    public class Project : Attribute
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectShortName { get; set; }
        public string Description { get; set; }
        [DefaultValue("getutcdate()")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual List<Task> Tasks { get; set; }
    }
}
