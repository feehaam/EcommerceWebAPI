using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApplication.Migrations
{
    /// <inheritdoc />
    public partial class attempt18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentStatus_PaymentStatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentStatus_PaymentStatusId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentStatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentStatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentSystem",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "PaymentStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentStatusId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryStatus",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_OrderId",
                table: "PaymentStatus",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentStatus_PaymentStatusId",
                table: "Payment",
                column: "PaymentStatusId",
                principalTable: "PaymentStatus",
                principalColumn: "PaymentStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentStatus_Order_OrderId",
                table: "PaymentStatus",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentStatus_PaymentStatusId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentStatus_Order_OrderId",
                table: "PaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_PaymentStatus_OrderId",
                table: "PaymentStatus");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentStatus");

            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentStatusId",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentSystem",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentStatusId",
                table: "Order",
                column: "PaymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentStatus_PaymentStatusId",
                table: "Order",
                column: "PaymentStatusId",
                principalTable: "PaymentStatus",
                principalColumn: "PaymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentStatus_PaymentStatusId",
                table: "Payment",
                column: "PaymentStatusId",
                principalTable: "PaymentStatus",
                principalColumn: "PaymentStatusId");
        }
    }
}
