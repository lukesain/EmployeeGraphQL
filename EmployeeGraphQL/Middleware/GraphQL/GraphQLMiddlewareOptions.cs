using GraphQL.Validation.Complexity;

namespace EmployeeGraphQL.Middleware.GraphQL
{
    public class GraphQLMiddlewareOptions
    {
        public string SchemaName { get; set; }
        public string AuthorizationPolicy { get; set; }

        public bool FormatOutput { get; set; } = true;
        public ComplexityConfiguration ComplexityConfiguration { get; set; } = new ComplexityConfiguration();
        public bool ExposeExceptions { get; set; }
    }
}
