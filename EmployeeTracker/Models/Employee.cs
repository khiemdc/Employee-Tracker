using System;
using System.Collections.Generic;

namespace EmployeeTracker.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionId { get; set; }
        public int OfficeId { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
        public DateTime UpdatedUtc { get; set; }

        public virtual Office Office { get; set; }
        public virtual Position Position { get; set; }
    }
}
