using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 17, 16, 46, 28, 628, DateTimeKind.Local).AddTicks(2113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 14, 22, 8, 28, 914, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Goods",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseUnit",
                table: "Goods",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 17, 16, 46, 28, 625, DateTimeKind.Local).AddTicks(981),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 14, 22, 8, 28, 912, DateTimeKind.Local).AddTicks(6831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 17, 16, 46, 28, 619, DateTimeKind.Local).AddTicks(7670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 14, 22, 8, 28, 910, DateTimeKind.Local).AddTicks(3516));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "PurchaseUnit",
                table: "Goods");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 14, 22, 8, 28, 914, DateTimeKind.Local).AddTicks(4417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 17, 16, 46, 28, 628, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 14, 22, 8, 28, 912, DateTimeKind.Local).AddTicks(6831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 17, 16, 46, 28, 625, DateTimeKind.Local).AddTicks(981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 14, 22, 8, 28, 910, DateTimeKind.Local).AddTicks(3516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 17, 16, 46, 28, 619, DateTimeKind.Local).AddTicks(7670));
        }
    }
}
