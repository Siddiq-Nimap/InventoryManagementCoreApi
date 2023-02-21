using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManagementWebAPI.Migrations
{
    public partial class Adding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatagoryLists_CId",
                table: "CatagoryLists",
                column: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatagoryLists_Catagories_CId",
                table: "CatagoryLists",
                column: "CId",
                principalTable: "Catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatagoryLists_Products_PId",
                table: "CatagoryLists",
                column: "PId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatagoryLists_Catagories_CId",
                table: "CatagoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CatagoryLists_Products_PId",
                table: "CatagoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CatagoryLists_CId",
                table: "CatagoryLists");
        }
    }
}
