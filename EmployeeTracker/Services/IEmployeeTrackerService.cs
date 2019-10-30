using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public interface IEmployeeTrackerService
    {
        IEnumerable<Employee>GetAllEmployee();
        string GetOffice(int id);
        string GetPosition(int id);

    }
}
