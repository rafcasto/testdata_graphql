using GraphQL.Types;
using TestDataCore.Contracts;
using TestDataCore.ModelGraphQL;

namespace TestDataApi.GraphQLSchemas
{
    public class GraphqlQuery:ObjectGraphType
    {
        public GraphqlQuery(IUserRepository userRepository)
        {
            Name = "Query";
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => 
                {
                    return userRepository.GetUsers();
                }
            );
        }
    }
}