using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    /// <inheritdoc />
    public partial class j : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tcarts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tcarts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Tcategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tcategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tusers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tusers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Tusers_Tcarts_CartId",
                        column: x => x.CartId,
                        principalTable: "Tcarts",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateTable(
                name: "Tproducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductImages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    ProductDiscountedPrice = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tproducts", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Tproducts_Tcategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tcategories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Torders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    ShipmentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Torders_Tcarts_CartId",
                        column: x => x.CartId,
                        principalTable: "Tcarts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_Torders_Tusers_UserId",
                        column: x => x.UserId,
                        principalTable: "Tusers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TcartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TcartItems_Tcarts_CartId",
                        column: x => x.CartId,
                        principalTable: "Tcarts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_TcartItems_Tproducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tproducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TcartItems_CartId",
                table: "TcartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_TcartItems_ProductId",
                table: "TcartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Torders_CartId",
                table: "Torders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Torders_UserId",
                table: "Torders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tproducts_CategoryId",
                table: "Tproducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tusers_CartId",
                table: "Tusers",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TcartItems");

            migrationBuilder.DropTable(
                name: "Torders");

            migrationBuilder.DropTable(
                name: "Tproducts");

            migrationBuilder.DropTable(
                name: "Tusers");

            migrationBuilder.DropTable(
                name: "Tcategories");

            migrationBuilder.DropTable(
                name: "Tcarts");
        }
    }
}
