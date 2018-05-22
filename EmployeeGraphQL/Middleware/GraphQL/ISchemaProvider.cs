using System;
using GraphQL.Types;

namespace EmployeeGraphQL.Middleware.GraphQL
{
    public interface ISchemaProvider
    {
        string Name { get; }

        ISchema Create(IServiceProvider services);
    }
}