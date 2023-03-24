using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    /// <inheritdoc />
    public partial class @as : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tproducts_Tcategories_CategoryId",
                table: "Tproducts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tproducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tproducts_Tcategories_CategoryId",
                table: "Tproducts",
                column: "CategoryId",
                principalTable: "Tcategories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tproducts_Tcategories_CategoryId",
                table: "Tproducts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tproducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tproducts_Tcategories_CategoryId",
                table: "Tproducts",
                column: "CategoryId",
                principalTable: "Tcategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
