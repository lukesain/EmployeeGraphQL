using System;

namespace EmployeeGraphQL.Domain
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public DateTime EmploymentDate { get; set; }

        public DepartmentInfo Department { get; set; }

        public PersonalInfo Profile { get; set; }
    }
}
