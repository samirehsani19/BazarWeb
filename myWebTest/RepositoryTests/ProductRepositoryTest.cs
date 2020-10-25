using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using myweb;
using myweb.Models;
using myweb.Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace myWebTest
{
    public class ProductRepositoryTest
    {
        [Fact]
        public async void GetAllProduct_IfAnyExist_ExpectedTrue()
        {
            //Arrange
            var mockContext = new Mock<DataContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(GetProducts());

            var mockILogger = Mock.Of<ILogger<ProductRepository>>();
            var repository = new ProductRepository(mockContext.Object, mockILogger);

            //Act
            var result = await repository.GetAllProduct();

            //Assert
            Assert.True(result.Length > 0);
        }

        [Theory]
        [InlineData(1,"Iphone 5")]
        public async void GetProductById_IfProductIdGreaterThanZero_ExpectedProductName(int id, string expectedName)
        {
            //Arrange
            var context = new Mock<DataContext>();
            context.Setup(c => c.Products).ReturnsDbSet(GetProducts());
            var logger = Mock.Of<ILogger<ProductRepository>>();

            var repo = new ProductRepository(context.Object, logger);
            //Act
            var result = await repo.GetProductById(id);

            //Assert
            Assert.Equal(expectedName, result.ProductName);

        }
        public Product[] GetProducts()
        {
            return new Product[] 
            {
                new Product
                {
                    ProductID=1,
                    Description="new phone",
                     Image="example.png",
                     Price=1200,
                     ProductName="Iphone 5",
                     Quantity=2,
                },
                new Product
                {
                     ProductID=2,
                     Description="new bike",
                     Image="example2.png",
                     Price=3000,
                     ProductName="Monark female bike",
                     Quantity=1,
                },
            };
        }
    }
}
