using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.EF.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PetID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeID",
                table: "Transactions",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PetFoodID",
                table: "Transactions",
                column: "PetFoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PetID",
                table: "Transactions",
                column: "PetID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Employees_EmployeeID",
                table: "Transactions",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PetFood_PetFoodID",
                table: "Transactions",
                column: "PetFoodID",
                principalTable: "PetFood",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Pets_PetID",
                table: "Transactions",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmployeeID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PetFood_PetFoodID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Pets_PetID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_EmployeeID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PetFoodID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PetID",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "PetID",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
