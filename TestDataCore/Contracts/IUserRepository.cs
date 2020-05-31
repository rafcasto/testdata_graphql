using System.Collections.Generic;
using System.Threading.Tasks;
using TestDataCore.Model;

namespace TestDataCore.Contracts
{
    public interface IUserRepository
    {
         Task<List<User>> GetUsers();
    }
}