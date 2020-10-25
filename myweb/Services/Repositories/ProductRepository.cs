using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myweb.Models;
using myweb.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace myweb.Services.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(DataContext context, ILogger<Repository> logger) : base(context, logger)
        {
        }
        public virtual async Task<Product[]> GetAllProduct()
        {
            _logger.LogInformation("Getting all Products");
            IQueryable<Product> products = _context.Products.AsNoTracking();
            return await products.ToArrayAsync();
        }

        public virtual async Task<Product> GetProductById(int id)
        {
            _logger.LogInformation($"Getting product by id {id}");
            IQueryable<Product> result = _context.Products.AsNoTracking().Where(x => x.ProductID == id);
            return await result.FirstOrDefaultAsync();
        }
    }
}
