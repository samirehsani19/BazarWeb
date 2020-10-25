using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
using Moq.EntityFrameworkCore;
using myweb;
using myweb.Controllers;
using myweb.Models;
using myweb.Services.Interfaces;
using myweb.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace myWebTest.ControllerTests
{
    public class ProductControllerTes
    {
        [Fact]
        public async void Index_IfAnyProductExist_ExpectedTrue()
        {
            var mockContext = new Mock<DataContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(GetProducts());

            var logger = Mock.Of<ILogger<ProductRepository>>();
            var repo = new ProductRepository(mockContext.Object, logger);

            var controller = new ProductController(repo);

            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(
                viewResult.ViewData.Model);

            Assert.True(model.Count()> 0);

        }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductID=1,
                    ProductName="car",
                    Description="new car",
                    Image="no image",
                    Price=20000,
                    Quantity=2
                },
                new Product
                {
                    ProductID=2,
                    ProductName="bicycle",
                    Description="red bicycle",
                    Image="no image",
                    Price=3000,
                    Quantity=1
                }
            };
        }
    }
}
