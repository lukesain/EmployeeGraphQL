using EmployeeGraphQL.Domain;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphQL.Middleware.GraphQL.Types
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(x => x.FirstName).Description("The firstname of the employee");
            Field(x => x.LastName).Description("The lastname of the employee");
            Field(x => x.JobTitle).Description("The jobtitle of the employee");

            Field<DepartmentType>("department");
            Field<PersonalInfoType>("profile");
        }
    }
}
