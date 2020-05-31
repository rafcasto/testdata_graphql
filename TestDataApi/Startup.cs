using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL;
using TestDataCore.ModelGraphQL;
using TestDataCore.Model;
using TestDataCore.Contracts;
using TestDataBusiness.Repositories;
using GraphQL.Types;
using TestDataApi.GraphQLSchemas;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace TestDataApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This methord gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = false);
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<IDocumentWriter, DocumentWriter>();
            services.AddTransient<UserType>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddSingleton<ISchema,GraphqlSchema>();
            services.AddTransient<GraphqlQuery>();
            services.AddHttpContextAccessor();
            services.Configure<GraphQLSettings>(Configuration);
            services.Configure<GraphQLSettings>(settings => settings.BuildUserContext = ctx => new GraphQLUserContext { User = ctx.User });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             app.UseGraphiQLServer(
                 new GraphiQLOptions()
                 {
                     GraphiQLPath = "/graphql",
                     GraphQLEndPoint = "/graphql"
                 }
             );
             app.UseMiddleware<GraphQLMiddleware>();
                         app.UseGraphQLPlayground(new GraphQL.Server.Ui.Playground.GraphQLPlaygroundOptions()
                         {
                             GraphQLEndPoint = "/graphql",
                             Path = "/graphql"
                         });
            app.UseGraphQLAltair();
            app.UseGraphQLVoyager();

            
        }
    }
}
