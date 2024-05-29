using Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Job
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public string? Location { get; set; }

        public string? Requirements { get; set; }

        public string? Benefits { get; set; }

        public WorkingModelEnum WorkingModel { get; set; }

        public LevelEnum Level { get; set; }
    }
}
