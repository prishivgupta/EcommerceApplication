using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    /// <inheritdoc />
    public partial class addedModels : Migration
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

            migrationBuilder.CreateTable(
                name: "Tusers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhoneNumber = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_TcartItems_CartId",
                table: "TcartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_TcartItems_ProductId",
                table: "TcartItems",
                column: "ProductId");

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
                name: "Tusers");

            migrationBuilder.DropTable(
                name: "Tcarts");
        }
    }
}
