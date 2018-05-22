using EmployeeGraphQL.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Initialiser
{
    public class ServiceInitialiser
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<ISalaryService, SalaryService>();
        }
    }
}
