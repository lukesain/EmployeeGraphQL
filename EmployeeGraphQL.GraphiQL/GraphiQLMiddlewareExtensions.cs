using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeGraphQL.GraphiQL
{
    public static class GraphiqlMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphiQL(
            this IApplicationBuilder builder,
            PathString path,
            Action<GraphiQLMiddlewareOptions> configure)
        {
            var options = new GraphiQLMiddlewareOptions();
            configure(options);

            return builder.UseGraphiQL(path, options);
        }

        public static IApplicationBuilder UseGraphiQL(
            this IApplicationBuilder builder,
            PathString path,
            GraphiQLMiddlewareOptions options)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return builder.Map(path, branch => branch.UseMiddleware<GraphiQLMiddleware>(options));
        }
    }
}
