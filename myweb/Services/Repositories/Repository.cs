using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myweb.Services.Interfaces;
using System.Threading.Tasks;

namespace myweb.Services.Repositories
{
    public class Repository : IRepostory
    {
        protected readonly DataContext _context;
        protected readonly ILogger _logger;
        public Repository(DataContext context, ILogger<Repository> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public virtual void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _context.Add(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _context.Remove(entity);
        }

        public virtual async Task<bool> Save()
        {
            _logger.LogInformation($"Saving changes");
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
