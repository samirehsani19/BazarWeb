using myweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myweb.Services.Interfaces
{
    public interface IUserRepository:IRepostory
    {
        Task<User> GetUser(User user);
    }
}
