using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphQL.Domain.Repositories;
using EmployeeGraphQL.Domain.Services;
using EmployeeGraphQL.GraphiQL;
using EmployeeGraphQL.Initialiser;
using EmployeeGraphQL.Middleware;
using EmployeeGraphQL.Middleware.GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeGraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<EmployeeQuery>();
            services.AddSingleton<EmployeeType>();
            services.AddSingleton<DepartmentType>();
            services.AddSingleton<PersonalInfoType>();


            RepositoryInitialiser.Initialise(services);
            ServiceInitialiser.Initialise(services);

            services.AddGraphQL(schema =>
            {
                schema.SetQueryType<EmployeeQuery>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseGraphiQL("/graphiql", options =>
                {
                    options.GraphQLEndpoint = "/graphql";
                });
            }

            app.UseGraphQL("/graphql", options =>
            {
                options.FormatOutput = false; // Override default options registered in ConfigureServices
                options.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 }; //optional
            });

            app.UseMvc();
        }
    }
}
