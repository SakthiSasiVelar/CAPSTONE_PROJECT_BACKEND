using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toy_Store_Management_Backend.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_SuccessFulPaymentId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SuccessFulPaymentId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "SuccessFulPaymentId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 14, 54, 430, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 14, 54, 430, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 14, 54, 430, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 14, 54, 430, DateTimeKind.Local).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 14, 54, 430, DateTimeKind.Local).AddTicks(7505));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SuccessFulPaymentId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StripePaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 4, 15, 389, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 4, 15, 389, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 4, 15, 389, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 4, 15, 389, DateTimeKind.Local).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "Toys",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalDate",
                value: new DateTime(2024, 8, 2, 20, 4, 15, 389, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SuccessFulPaymentId",
                table: "Orders",
                column: "SuccessFulPaymentId",
                unique: true,
                filter: "[SuccessFulPaymentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_SuccessFulPaymentId",
                table: "Orders",
                column: "SuccessFulPaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
