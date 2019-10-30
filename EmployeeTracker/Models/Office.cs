using System;
using System.Collections.Generic;

namespace EmployeeTracker.Models
{
    public partial class Office
    {
        public Office()
        {
            Employee = new HashSet<Employee>();
        }

        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public DateTime UpdatedUtc { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
