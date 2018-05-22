using System;
using GraphQL;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeGraphQL.Middleware.GraphQL
{
    internal class GraphQLDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _services;

        public GraphQLDependencyResolver(IServiceProvider services)
        {
            _services = services;
        }

        public T Resolve<T>()
        {
            return _services.GetService<T>();
        }

        public object Resolve(Type type)
        {
            return _services.GetService(type);
        }
    }
}
