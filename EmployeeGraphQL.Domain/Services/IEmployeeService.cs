using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Domain.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();

        IEnumerable<Employee> FindByName(string name);

        Employee GetById(int id);
    }
}
