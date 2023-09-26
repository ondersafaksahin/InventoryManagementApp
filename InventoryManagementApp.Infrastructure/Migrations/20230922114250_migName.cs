using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubCategories",
                newName: "SubCategoryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Models",
                newName: "ModelName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "BrandName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 22, 14, 42, 49, 448, DateTimeKind.Local).AddTicks(6135),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 21, 21, 7, 35, 885, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 22, 14, 42, 49, 444, DateTimeKind.Local).AddTicks(3684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 21, 21, 7, 35, 881, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 22, 14, 42, 49, 432, DateTimeKind.Local).AddTicks(7971),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 21, 21, 7, 35, 868, DateTimeKind.Local).AddTicks(4326));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategoryName",
                table: "SubCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ModelName",
                table: "Models",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "Brands",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 21, 21, 7, 35, 885, DateTimeKind.Local).AddTicks(6176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 22, 14, 42, 49, 448, DateTimeKind.Local).AddTicks(6135));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 21, 21, 7, 35, 881, DateTimeKind.Local).AddTicks(8751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 22, 14, 42, 49, 444, DateTimeKind.Local).AddTicks(3684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 21, 21, 7, 35, 868, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 22, 14, 42, 49, 432, DateTimeKind.Local).AddTicks(7971));
        }
    }
}
