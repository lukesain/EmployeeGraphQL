﻿using System;
using EmployeeGraphQL.Middleware.GraphQL;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods used to add the middleware to the HTTP request pipeline.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds a GraphQL middleware to the <see cref="IApplicationBuilder"/> request execution pipeline with default options.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGraphQl(this IApplicationBuilder builder,
            PathString path)
        {
            return builder.UseGraphQL(path, new GraphQLMiddlewareOptions());
        }

        /// <summary>
        /// Adds a GraphQL middleware to the <see cref="IApplicationBuilder"/> request execution pipeline with a callback to configure options.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder,
            PathString path, Action<GraphQLMiddlewareOptions> configure)
        {
            var options = new GraphQLMiddlewareOptions();
            configure(options);

            return builder.UseGraphQL(path, options);
        }

        /// <summary>
        /// Adds a GraphQL middleware to the <see cref="IApplicationBuilder"/> request execution pipeline with the specified options.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder,
            PathString path, GraphQLMiddlewareOptions options)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var schemaProvider = SchemaConfiguration.GetSchemaProvider(options.SchemaName, builder.ApplicationServices);

            return builder.Map(path, branch => branch.UseMiddleware<GraphQLMiddleware>(schemaProvider, options));
        }
    }
}
