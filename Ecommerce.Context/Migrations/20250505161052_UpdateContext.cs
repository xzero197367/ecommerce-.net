using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_UserID",
                table: "products",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_products_User_UserID",
                table: "products",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_User_UserID",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_UserID",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "products");
        }
    }
}
