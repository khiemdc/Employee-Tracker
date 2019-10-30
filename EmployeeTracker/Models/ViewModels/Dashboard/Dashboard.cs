using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Models.ViewModels.Dashboard
{
    public class Dashboard
    {
        public int TotalPositions { get; set; }
        public int TotalOffices { get; set; }
        public int TotalEmployees { get; set; }

        public IEnumerable<ChartData> EmployeesPerYear { get; set; }
        public IEnumerable<ChartData> EmployeesPerOffice { get; set; }
    }
}
