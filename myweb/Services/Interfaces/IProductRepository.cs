using myweb.Models;
using System.Threading.Tasks;

namespace myweb.Services.Interfaces
{
    public interface IProductRepository : IRepostory
    {
        Task<Product[]> GetAllProduct();
        Task<Product> GetProductById(int id);
    }
}
