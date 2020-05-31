using GraphQL.Types;
using TestDataCore.Model;

namespace TestDataCore.ModelGraphQL
{
    public class UserType:ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(user => user.UserName,nullable:true).Description("Username");
            Field(user => user.Password,nullable:true).Description("Password");
            Field(user => user.IsActive,nullable:true).Description("Is customer active");
        }
    }
}