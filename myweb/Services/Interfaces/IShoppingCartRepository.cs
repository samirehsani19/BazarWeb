using myweb.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myweb.Services.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<List<ShoppingCartDto>> GetShoppingCartItem(int id);
    }
}
