using Newtonsoft.Json.Linq;

namespace EmployeeGraphQL.Middleware.GraphQL
{
    internal class GraphQLParameters
    {
        public string Query { get; set; }

        public string OperationName { get; set; }

        public JObject Variables { get; set; }
    }
}