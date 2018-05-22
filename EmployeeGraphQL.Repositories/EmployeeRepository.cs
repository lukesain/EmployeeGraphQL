using EmployeeGraphQL.Domain;
using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeGraphQL.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository()
        {
            int employeeId = FetchNextId();

            Data.Add(employeeId, new EmployeeEntity() { DateOfBirth = new DateTime(1980, 1, 1), DepartmentCode = "ABCD", Id = employeeId, EmploymentDate = DateTime.Now.AddMonths(-5), FirstName = "Mike", LastName = "Gamer", JobTitle = "AAB", SalaryCode = "AAAA" });

            employeeId = FetchNextId();
            Data.Add(employeeId, new EmployeeEntity() { DateOfBirth = new DateTime(1980, 1, 2), DepartmentCode = "ABCD", Id = employeeId, EmploymentDate = DateTime.Now.AddMonths(-5), FirstName = "Mark", LastName = "Poker", JobTitle = "AAC", SalaryCode = "CCCC" });

            employeeId = FetchNextId();
            Data.Add(employeeId, new EmployeeEntity() { DateOfBirth = new DateTime(1980, 1, 3), DepartmentCode = "ABCD", Id = employeeId, EmploymentDate = DateTime.Now.AddMonths(-5), FirstName = "John", LastName = "Smith", JobTitle = "AAB", SalaryCode = "AAAB" });

            employeeId = FetchNextId();
            Data.Add(employeeId, new EmployeeEntity() { DateOfBirth = new DateTime(1980, 1, 4), DepartmentCode = "ABCD", Id = employeeId, EmploymentDate = DateTime.Now.AddMonths(-5), FirstName = "Paul", LastName = "Smith", JobTitle = "AAD", SalaryCode = "DDDD" });

            employeeId = FetchNextId();
            Data.Add(employeeId, new EmployeeEntity() { DateOfBirth = new DateTime(1980, 1, 5), DepartmentCode = "ABCD", Id = employeeId, EmploymentDate = DateTime.Now.AddMonths(-5), FirstName = "Steve", LastName = "Jones", JobTitle = "AAE", SalaryCode = "EEEE" });
        }

        public IEnumerable<EmployeeEntity> GetByFirstName(string name)
        {
            return Data.Values.Where(x => x.FirstName == name);
        }

        public EmployeeEntity GetById(int id)
        {
            return Data[id];
        }

        public IEnumerable<EmployeeEntity> GetByLastName(string name)
        {
            return Data.Values.Where(x => x.LastName == name);
        }
    }
}
