using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myweb.Models;
using myweb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myweb.Services.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DataContext context, ILogger<Repository> logger) : base(context, logger)
        {
        }

        public async Task<User> GetUser(User user)
        {
            _logger.LogInformation($"Getting user {user.Username}");
            IQueryable<User> result = _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password);
            return await result.FirstOrDefaultAsync();
        }
    }
}
