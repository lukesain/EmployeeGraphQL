using EmployeeGraphQL.Domain;
using GraphQL.Types;

namespace EmployeeGraphQL.Middleware.GraphQL.Types
{
    internal class PersonalInfoType : ObjectGraphType<PersonalInfo>
    {
        public PersonalInfoType()
        {
            Field(x => x.DateOfBith).Description("The persons date of birth");
            Field(x => x.MonthlySalary).Description("how much this person is paid per month");
        }
    }
}