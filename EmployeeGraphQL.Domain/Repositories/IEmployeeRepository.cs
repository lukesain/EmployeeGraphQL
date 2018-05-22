using EmployeeGraphQL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeEntity> GetAll();
        IEnumerable<EmployeeEntity> GetByFirstName(string name);
        IEnumerable<EmployeeEntity> GetByLastName(string name);
        EmployeeEntity GetById(int id);
    }
}
