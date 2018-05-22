using EmployeeGraphQL.Repositories.Entities.Interfaces;
using System;

namespace EmployeeGraphQL.Repositories.Entities
{
    public class EmployeeEntity : IDataEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DepartmentCode { get; set; }
        public string SalaryCode { get; set; }
    }
}
