using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlämning1Tomaso.Migrations
{
    /// <inheritdoc />
    public partial class ThirdInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Category_CategoryID",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CategoryID",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Dishes");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryID",
                table: "Dishes",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Category_CategoryID",
                table: "Dishes",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID");
        }
    }
}
