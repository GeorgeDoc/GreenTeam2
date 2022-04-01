using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.EF.Migrations
{
    public partial class Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PetShop");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "PetShop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "PetShop",
                newName: "Customer");
        }
    }
}
