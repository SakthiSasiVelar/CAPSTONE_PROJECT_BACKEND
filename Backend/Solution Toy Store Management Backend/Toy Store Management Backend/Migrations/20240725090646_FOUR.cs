using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toy_Store_Management_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FOUR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_SuccessFulPaymentId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SuccessFulPaymentId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SuccessFulPaymentId",
                table: "Orders",
                column: "SuccessFulPaymentId",
                unique: true,
                filter: "[SuccessFulPaymentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_SuccessFulPaymentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SuccessFulPaymentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SuccessFulPaymentId",
                table: "Orders",
                column: "SuccessFulPaymentId",
                unique: true);
        }
    }
}
