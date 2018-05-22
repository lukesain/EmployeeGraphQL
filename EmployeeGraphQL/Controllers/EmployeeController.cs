using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphQL.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeGraphQL.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            var employees = _employeeService.GetAll();

            foreach (var employee in employees)
            {
                yield return new EmployeeModel()
                {
                    Name = String.Format($"{employee.FirstName} {employee.LastName}"),
                    JobTitle = employee.JobTitle
                };
            }
        }
    }
}