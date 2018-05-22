using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeGraphQL.Initialiser
{
    public class RepositoryInitialiser
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<ISalaryRepository, SalaryRepository>();
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
