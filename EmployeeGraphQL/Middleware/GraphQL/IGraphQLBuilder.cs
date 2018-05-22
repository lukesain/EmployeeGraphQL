using System;
using GraphQL.Execution;

namespace EmployeeGraphQL.Middleware.GraphQL
{
    public interface IGraphQLBuilder
    {
        /// <summary>
        /// Configure another schema
        /// </summary>
        /// <param name="name"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        IGraphQLBuilder AddSchema(string name, Action<SchemaConfiguration> configure);

        /// <summary>
        /// Adds a <see cref="IDocumentExecutionListener"/>.
        /// </summary>
        /// <typeparam name="T">The listener to add.</typeparam>
        /// <returns></returns>
        IGraphQLBuilder AddDocumentExecutionListener<T>()
            where T : class, IDocumentExecutionListener;

        /// <summary>
        /// Adds Data Loader support.
        /// </summary>
        /// <returns></returns>
        IGraphQLBuilder AddDataLoader();
        
        IGraphQLBuilder AddGraphTypes();
    }
}
