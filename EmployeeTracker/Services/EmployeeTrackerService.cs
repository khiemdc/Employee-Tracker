using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTracker.Models;

namespace EmployeeTracker.Services
{
    public class EmployeeTrackerService : IEmployeeTrackerService
    {
        private EmployeeTrackerContext _context;

        public EmployeeTrackerService(EmployeeTrackerContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employee.ToList();
        }

        //Get specific Office base on Id passed
        public string GetOffice(int id)
        {
            return _context.Office.Single(o => o.OfficeId == id).OfficeName;
        }

        // Get specific Position base on id passed
        public string GetPosition(int Id)
        {
            return _context.Position.Single(p => p.PositionId == Id).PositionName;
        }
    }
}
