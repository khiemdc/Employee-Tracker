using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTracker.Models.ViewModels.Dashboard;
using EmployeeTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/dashboards")]
    public class DashboardsController : Controller
    {
        //create the property of type IDashboardService
        private IDashBoardService _dashboardService;


        public DashboardsController(IDashBoardService dashboardService)
        {
            _dashboardService = dashboardService;
        }



        // GET: api/Dashboards
        [HttpGet]
        public ActionResult Get()
        {

            
            var dashboardResult = new Dashboard
            {
                TotalOffices = _dashboardService.TotalOffice(),
                TotalPositions = _dashboardService.TotalPosition(),
                TotalEmployees = _dashboardService.TotalEmployee(),
                EmployeesPerOffice = _dashboardService.EmployeePerOffice(),
                EmployeesPerYear = _dashboardService.EmployeePerYear()

            };

            return Ok(dashboardResult);


        }


    }
}