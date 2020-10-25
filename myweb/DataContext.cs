using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myweb.Models;

namespace myweb
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            var connection = config.GetConnectionString("LocalConnection");
            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 1,
                ProductName = "Chair",
                Quantity = 1,
                Price = 200,
                Description = "a perfect chair for the office",
                Image = "chair.jpg"

            }, new Product
            {
                ProductID = 2,
                ProductName = "Acer Laptop",
                Quantity = 1,
                Price = 2000,
                Description = "Almost new laptop with 8gb ram and 250 ssd hard drive",
                Image = "laptop.jpg"
            }, new Product
            {
                ProductID = 3,
                ProductName = "Call of duty",
                Quantity = 3,
                Price = 300,
                Description = "Brand new ",
                Image = "game.jpg"
            }, new Product
            {
                ProductID = 4,
                ProductName = "Bicycle",
                Quantity = 1,
                Price = 1200,
                Description = "Brand new bicycle with 7 gears ",
                Image = "bicycle.jpg"
            }, new Product
            {
                ProductID = 5,
                ProductName = "Shoes",
                Quantity = 2,
                Price = 200,
                Description = "New shoes size 42 ",
                Image = "shoes.jpeg"
            }, new Product
            {
                ProductID = 6,
                ProductName = "Iphone 5",
                Quantity = 1,
                Price = 1300,
                Description = "Used one year but still funtional ",
                Image = "iphone.jpg"
            }
            );
        }
    }
}
