using EmployeeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public interface IDashBoardService
    {
        //Employee GetById(int id)

        int TotalPosition();
        int TotalOffice();
        int TotalEmployee();

        IEnumerable<ChartData>EmployeePerYear();
        IEnumerable<ChartData>EmployeePerOffice();
    }
}
