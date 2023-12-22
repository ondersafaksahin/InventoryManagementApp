using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class h1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 22, 12, 6, 16, 311, DateTimeKind.Local).AddTicks(2588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 15, 13, 28, 49, 402, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 22, 12, 6, 16, 310, DateTimeKind.Local).AddTicks(3715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 15, 13, 28, 49, 400, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 22, 12, 6, 16, 309, DateTimeKind.Local).AddTicks(2933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 15, 13, 28, 49, 398, DateTimeKind.Local).AddTicks(9822));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 15, 13, 28, 49, 402, DateTimeKind.Local).AddTicks(6900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 22, 12, 6, 16, 311, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 15, 13, 28, 49, 400, DateTimeKind.Local).AddTicks(6775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 22, 12, 6, 16, 310, DateTimeKind.Local).AddTicks(3715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 15, 13, 28, 49, 398, DateTimeKind.Local).AddTicks(9822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 22, 12, 6, 16, 309, DateTimeKind.Local).AddTicks(2933));
        }
    }
}
