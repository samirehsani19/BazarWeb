using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myweb.Models;
using myweb.Services.Interfaces;
using myweb.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace myweb.Controllers
{
    [ApiController]
    [Route("api/v1.0/Shopping")]

    public class ShoppingController : Controller
    {
        List<ShoppingCartDto> cartItems = new List<ShoppingCartDto>();
        private readonly IShoppingCartRepository repo;
        public ShoppingController(IShoppingCartRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            if (HttpContext.Session.GetInt32("counter") != null)
            {
                cartItems = JsonConvert.DeserializeObject<List<ShoppingCartDto>>(HttpContext.Session.GetString("data"));
                return View(cartItems);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShoppingCart(Product id)
        {
            cartItems = await repo.GetShoppingCartItem(id.ProductID);
            return Ok(HttpContext.Session.GetInt32("counter"));
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            cartItems = JsonConvert.DeserializeObject<List<ShoppingCartDto>>(HttpContext.Session.GetString("data"));
            int productQuantity = cartItems.Where(x => x.ProductID == id).Select(x => x.Quantity).FirstOrDefault();

            if (productQuantity == 1)
            {
                ShoppingCartDto removeItem = cartItems.Where(x => x.ProductID == id).FirstOrDefault();
                if (removeItem != null)
                {
                    cartItems.Remove(removeItem);
                    HttpContext.Session.SetString("data", JsonConvert.SerializeObject(cartItems));
                    HttpContext.Session.SetInt32("counter", cartItems.Count);
                }
            }
            else
            {
                cartItems.Where(x => x.ProductID == id).Select(x => { x.Quantity = x.Quantity - 1; x.Total = x.Price * x.Quantity; return x; }).ToList();
                HttpContext.Session.SetString("data", JsonConvert.SerializeObject(cartItems));
                HttpContext.Session.SetInt32("counter", cartItems.Count);
            }

            return RedirectToAction("ShoppingCart");
        }

        [HttpGet]
        [Route("Receipt")]
        public IActionResult Receipt()
        {
            cartItems = JsonConvert.DeserializeObject<List<ShoppingCartDto>>(HttpContext.Session.GetString("data"));
            return View(cartItems);
        }

    }
}
