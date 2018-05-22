using EmployeeGraphQL.Domain;
using GraphQL.Types;

namespace EmployeeGraphQL.Middleware.GraphQL.Types
{
    public class DepartmentType : ObjectGraphType<DepartmentInfo>
    {
        public DepartmentType()
        {
            Field(x => x.Code).Description("The unique code of the department");
            Field(x => x.Name).Description("The name of the department");
        }

    }
}