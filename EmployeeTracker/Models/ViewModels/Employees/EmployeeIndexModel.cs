using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Models.ViewModels.Employees
{
    public class EmployeeIndexModel
    {
        public IEnumerable<EmployeeAssetModel> Employees { get; set; }
    }
}
