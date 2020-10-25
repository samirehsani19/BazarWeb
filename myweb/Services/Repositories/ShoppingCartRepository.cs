using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using myweb.Models;
using myweb.Services.Interfaces;
using myweb.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myweb.Services.Repositories
{
    public class ShoppingCartRepository : ProductRepository, IShoppingCartRepository
    {
        private readonly IHttpContextAccessor accessor;
        public ShoppingCartRepository(IHttpContextAccessor a, DataContext context, ILogger<Repository> logger) : base(context, logger)
        {
            this.accessor = a;
        }

        public virtual async Task<List<ShoppingCartDto>> GetShoppingCartItem(int id)
        {
            _logger.LogInformation($"Getting shopping cart items");
            List<ShoppingCartDto> listOfShoppingCart = new List<ShoppingCartDto>();
            Product product = await GetProductById(id);

            if (accessor.HttpContext.Session.GetInt32("counter") != null)
            {
                listOfShoppingCart = JsonConvert.DeserializeObject<List<ShoppingCartDto>>(accessor.HttpContext.Session.GetString("data"));
            }

            if (listOfShoppingCart.Any(x => x.ProductID == id))
            {
                listOfShoppingCart.Where(x => x.ProductID == id).Select(x => { x.Quantity = x.Quantity + 1; x.Total = x.Quantity * x.Price; return x; }).ToList();
            }
            else
            {
                ShoppingCartDto dto = new ShoppingCartDto
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    Image = product.Image,
                    Quantity = 1,
                    Total = product.Price
                };

                listOfShoppingCart.Add(dto);
            }

            accessor.HttpContext.Session.SetInt32("counter", listOfShoppingCart.Count);
            accessor.HttpContext.Session.SetString("data", JsonConvert.SerializeObject(listOfShoppingCart));

            return listOfShoppingCart;
        }
    }
}
