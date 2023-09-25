using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nlayer.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFetures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFetures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFetures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdateDate" },
                values: new object[] { 1, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(181), "Kalemler", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdateDate" },
                values: new object[] { 2, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(195), "Kitaplar", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdateDate" },
                values: new object[] { 3, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(196), "Defterler", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(527), "Kalem 1", 100m, 34, null },
                    { 2, 1, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(530), "Kalem 2", 400m, 45, null },
                    { 3, 1, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(532), "Kalem 3", 130m, 24, null },
                    { 4, 2, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(533), "Kitap 1", 130m, 24, null },
                    { 5, 2, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(534), "Kitap 2", 130m, 24, null },
                    { 6, 3, new DateTime(2023, 9, 23, 14, 49, 47, 153, DateTimeKind.Local).AddTicks(535), "Defter 2", 130m, 24, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFetures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 1, "Mor", 12, 1, 8 });

            migrationBuilder.InsertData(
                table: "ProductFetures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 2, "Mavi", 14, 2, 9 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFetures_ProductId",
                table: "ProductFetures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFetures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
