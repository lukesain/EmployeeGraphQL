using System;
using GraphQL.DataLoader;
using GraphQL.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeGraphQL.Middleware.GraphQL
{
    public class GraphQLBuilder : IGraphQLBuilder
    {
        private readonly IServiceCollection _services;

        public GraphQLBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public IGraphQLBuilder AddSchema(string name, Action<SchemaConfiguration> configure)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var schema = new SchemaConfiguration(name);
            configure(schema);

            _services.AddSingleton<ISchemaProvider>(schema);

            return this;
        }
        
        public IGraphQLBuilder AddDocumentExecutionListener<T>()
            where T: class, IDocumentExecutionListener
        {
            _services.AddSingleton<IDocumentExecutionListener, T>();
            return this;
        }
        
        public IGraphQLBuilder AddDataLoader()
        {
            _services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            AddDocumentExecutionListener<DataLoaderDocumentListener>();
            return this;
        }

        internal IGraphQLBuilder AddSchema(SchemaConfiguration schema)
        {
            _services.AddSingleton<ISchemaProvider>(schema);

            return this;
        }

        public IGraphQLBuilder AddGraphTypes()
        {
            throw new NotImplementedException();
        }
    }
}
