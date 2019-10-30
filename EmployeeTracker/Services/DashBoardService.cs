using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracker.Services
{
    public class DashBoardService : IDashBoardService
    {
        private EmployeeTrackerContext _context;

        public DashBoardService(EmployeeTrackerContext context)
        {
            _context = context;
        }

        public int TotalPosition()
        {
            return _context.Position.Count();
        }

        public int TotalOffice()
        {
            return _context.Office.Count();
        }

        public int TotalEmployee()
        {
            return _context.Employee.Count();
        }

        public IEnumerable<ChartData> EmployeePerYear()
        {
            // get list of employees
            var listOfEmployee = _context.Employee;
            //Group the  employees by startDate and the result be save in key value pair type of chartaData,  
            //    get the result key as Key and count the result as Value.
            var chartdata = listOfEmployee.AsEnumerable().GroupBy(a => new { a.StartDate.Year }).Select(result => new ChartData
            {
                Key = result.Key.Year.ToString(),
                Value = result.Count()

            });
            return chartdata;
        }

        public IEnumerable<ChartData> EmployeePerOffice()
        {
            // Get All Employee included their respectif office
            var listOfEmployee = _context.Employee.Include(a => a.Office);
            // Group the employee by ofifice select result and save it to the chartData proprties as key, value pair.
            var chartdata = listOfEmployee.AsEnumerable().GroupBy(a => new { a.OfficeId, a.Office }).Select(result => new ChartData
            {
                Key = result.Key.Office.OfficeName.ToString(),
                Value = result.Count()
            });
            return chartdata;
        }

    }
}
