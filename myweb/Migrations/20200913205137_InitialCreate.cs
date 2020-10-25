using Microsoft.EntityFrameworkCore.Migrations;
namespace myweb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producs",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producs", x => x.ProductID);
                });

            migrationBuilder.InsertData(
                table: "Producs",
                columns: new[] { "ProductID", "Adress", "Description", "Image", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, "Liseberg, Gathenburg", "a perfect chair for the office", "chair.jpg", 200, "Chair", 1 },
                    { 2, "Hisingen, Gathenburg", "Almost new laptop with 8gb ram and 250 ssd hard drive", "laptop.jpg", 2000, "Acer Laptop", 1 },
                    { 3, "Mölndal, Gathenburg", "Brand new ", "game.jpg", 300, "Call of duty", 3 },
                    { 4, "Majorna, Gathenburg", "Brand new bicycle with 7 gears ", "bicycle.jpg", 1200, "Bicycle", 1 },
                    { 5, "Mölndal, Gathenburg", "New shoes size 42 ", "shoes.jpeg", 200, "Shoes", 2 },
                    { 6, "Gottsunda, Uppsala", "Used one year but still funtional ", "iphone.jpg", 1300, "Iphone 5", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producs");
        }
    }
}
