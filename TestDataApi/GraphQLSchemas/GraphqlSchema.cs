using System;
using GraphQL.Types;

using GraphQL.Utilities;
namespace TestDataApi.GraphQLSchemas
{
    public class GraphqlSchema: Schema
    {
        public GraphqlSchema(IServiceProvider serviceProvider):base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<GraphqlQuery>();
        }
    }
}