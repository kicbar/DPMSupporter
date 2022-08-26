using System;
using System.Collections.Generic;

namespace DPMSupporter.API.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectShortName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual List<Task> Tasks { get; set; }
    }
}
