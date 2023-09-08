using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_batch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 8, 11, 22, 19, 310, DateTimeKind.Local).AddTicks(6715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 545, DateTimeKind.Local).AddTicks(3811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 8, 11, 22, 19, 308, DateTimeKind.Local).AddTicks(2436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 543, DateTimeKind.Local).AddTicks(8510));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 8, 11, 22, 19, 305, DateTimeKind.Local).AddTicks(4011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 541, DateTimeKind.Local).AddTicks(4862));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 545, DateTimeKind.Local).AddTicks(3811),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 8, 11, 22, 19, 310, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 543, DateTimeKind.Local).AddTicks(8510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 8, 11, 22, 19, 308, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 541, DateTimeKind.Local).AddTicks(4862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 8, 11, 22, 19, 305, DateTimeKind.Local).AddTicks(4011));
        }
    }
}
