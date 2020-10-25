using Microsoft.EntityFrameworkCore.Migrations;

namespace myweb.Migrations
{
    public partial class CreateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Producs",
                table: "Producs");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Producs");

            migrationBuilder.RenameTable(
                name: "Producs",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Producs");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Producs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producs",
                table: "Producs",
                column: "ProductID");

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "Adress",
                value: "Liseberg, Gathenburg");

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "Adress",
                value: "Hisingen, Gathenburg");

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "Adress",
                value: "Mölndal, Gathenburg");

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "Adress",
                value: "Majorna, Gathenburg");

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "Adress",
                value: "Mölndal, Gathenburg");

            migrationBuilder.UpdateData(
                table: "Producs",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "Adress",
                value: "Gottsunda, Uppsala");
        }
    }
}
