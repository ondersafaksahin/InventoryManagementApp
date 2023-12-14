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
                defaultValue: new DateTime(2023, 12, 13, 15, 10, 18, 980, DateTimeKind.Local).AddTicks(444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 12, 13, 58, 21, 77, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 10, 18, 979, DateTimeKind.Local).AddTicks(1379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 12, 13, 58, 21, 76, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 10, 18, 978, DateTimeKind.Local).AddTicks(112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 12, 13, 58, 21, 75, DateTimeKind.Local).AddTicks(3073));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 12, 13, 58, 21, 77, DateTimeKind.Local).AddTicks(2002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 10, 18, 980, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 12, 13, 58, 21, 76, DateTimeKind.Local).AddTicks(3632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 10, 18, 979, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 12, 13, 58, 21, 75, DateTimeKind.Local).AddTicks(3073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 10, 18, 978, DateTimeKind.Local).AddTicks(112));
        }
    }
}
