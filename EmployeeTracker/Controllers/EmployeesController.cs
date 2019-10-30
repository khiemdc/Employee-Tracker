using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTracker.Models.ViewModels.Employees;
using EmployeeTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTracker.Controllers
{
    [Produces("application/json")]
        [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeTrackerService _employeeTrackerService;
        public EmployeesController(IEmployeeTrackerService employeeTrackerService)
        {
            _employeeTrackerService = employeeTrackerService;
        }
        // GET api/employees
        public IActionResult Get()
        {
            //Get all the employees from the database refered to the domain modol
            var employeesList = _employeeTrackerService.GetAllEmployee();

            // We need to transform the Domain model to View Model to get the json object we want.
            var employeeListResult = employeesList.Select(result => new EmployeeAssetModel
            {
                Id = result.EmployeeId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                //Modified PositionId & OfficeId to Position & Office name.
                Position = _employeeTrackerService.GetPosition(result.PositionId),
                Office = _employeeTrackerService.GetOffice(result.OfficeId),
                Sex = result.Sex,
                Age = result.Age,
                Salary = result.Salary,
                StartDate = result.StartDate,
                UpdatedUtc = result.UpdatedUtc
            });
            //Create the EmployeeIndexModel object that is IEnumerable of EmployeeAsetModel to return to the View
            var model = new EmployeeIndexModel
            {
                Employees = employeeListResult
            };
            return Ok(model);
        }
        
    }
}