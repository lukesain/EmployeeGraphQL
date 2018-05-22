using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Domain.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphQL.Middleware.GraphQL.Types
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeService service)
        {
            Field<ListGraphType<EmployeeType>>("employeebyname",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "name" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    return service.FindByName(name);
                });

            Field<ListGraphType<EmployeeType>>("employees",
                resolve: context =>
                {
                    return service.GetAll();
                });

            Field<EmployeeType>("employeebyid", 
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "employeeid" }), 
                resolve: context =>
                {
                    var employeeId = context.GetArgument<int>("employeeid");
                    return service.GetById(employeeId);
                });
        }
    }
}
