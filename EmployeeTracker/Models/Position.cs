using System;
using System.Collections.Generic;

namespace EmployeeTracker.Models
{
    public partial class Position
    {
        public Position()
        {
            Employee = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public DateTime UpdatedUtc { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
