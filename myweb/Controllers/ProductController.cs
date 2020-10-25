using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using myweb.Models;
using myweb.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace myweb.Controllers
{
    [ApiController]
    [Route("api/v1.0/Products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public async Task<ActionResult<Product[]>> Index()
        {
            try
            {
                Product[] product = await _repo.GetAllProduct();
                return View(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure {e.Message}");
            }
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View("Views/Product/Add.cshtml");
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromForm] Product product, IFormFile photo)
        {
            if (photo == null)
            {
                product.Image = "noImage.png";
            }
            else
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyTo(stream);
                product.Image = photo.FileName;
                stream.Close();
            }

            Product[] products = new Product[] { product };

            _repo.Add(product);
            await _repo.Save();
            return View("Views/Product/Index.cshtml", products);
        }

        [HttpGet]
        [Route("Main")]
        public async Task<IActionResult> Main()
        {
            var result = await _repo.GetAllProduct();
            return View("Views/Product/Main.cshtml", result);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetProductById(id);
            _repo.Delete(product);
            if (await _repo.Save())
            {
                return RedirectToAction("Main");
            }
            return View("Views/product/Error.cshtml");
        }
        
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult>Edit(int id)
        {
            var product = await _repo.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult>Edit(int id, [FromForm]Product product, IFormFile image)
        {
            var oldProduct = await _repo.GetProductById(id);
            if (oldProduct == null)
            {
                return View("Views/product/Error.cshtml");
            }

            if (image==null || image.Length==0)
            {
                product.Image = oldProduct.Image;
            }
            else
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", image.FileName);
                var stream = new FileStream(path, FileMode.Create);
                image.CopyTo(stream);
                product.Image = image.FileName;
                stream.Close();
            }

            _repo.Update(product);
            if (await _repo.Save())
            {
                return RedirectToAction("Main");
            }
            return View("Views/product/Error.cshtml");
        }
    }
}
