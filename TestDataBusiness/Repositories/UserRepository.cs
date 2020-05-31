using System.Collections.Generic;
using System.Threading.Tasks;
using TestDataCore.Contracts;
using TestDataCore.Model;

namespace TestDataBusiness.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<List<User>> GetUsers()
        {
           return Task.FromResult(FetchUsers());
        }

        private List<User> FetchUsers()
        {
            return new List<User>()
            {
                new User(){UserName="User1",Password="Password",IsActive=true},
                new User(){UserName="User2",Password="Password",IsActive=true},
                new User(){UserName="User3",Password="Password",IsActive=true},
                new User(){UserName="User4",Password="Password",IsActive=true},
            };
        }
    }
}