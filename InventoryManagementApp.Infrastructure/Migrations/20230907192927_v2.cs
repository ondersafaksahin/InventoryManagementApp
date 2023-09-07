using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_Id",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_BillOfMaterialDetails_BillOfMaterials_BillOfMaterialId",
                table: "BillOfMaterialDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillOfMaterialDetails_Goods_GoodID",
                table: "BillOfMaterialDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Goods_GoodID",
                table: "Consumptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_ProductionOrders_ProductionOrderId",
                table: "Consumptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversions_Goods_GoodID",
                table: "Conversions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_BillOfMaterials_ID",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodShelf_Goods_GoodsID",
                table: "GoodShelf");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodShelf_Shelves_ShelvesID",
                table: "GoodShelf");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodSupplier_Goods_MaterialsProducingID",
                table: "GoodSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodSupplier_Suppliers_SuppliersID",
                table: "GoodSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodWarehouse_Goods_GoodsID",
                table: "GoodWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodWarehouse_Warehouses_WarehousesID",
                table: "GoodWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_Id",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Batches_ID",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Goods_GoodId",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Batches_ID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Goods_GoodID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Warehouses_DestinationWarehouseID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierID",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Goods_GoodId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_Goods_GoodID",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderID",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransfers_Goods_GoodId",
                table: "StockTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryID",
                table: "SubCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 545, DateTimeKind.Local).AddTicks(3811),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 9, 48, 52, 19, DateTimeKind.Local).AddTicks(2879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 543, DateTimeKind.Local).AddTicks(8510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 9, 48, 52, 16, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.AlterColumn<int>(
                name: "GoodID",
                table: "Batches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 541, DateTimeKind.Local).AddTicks(4862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 9, 48, 52, 11, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_Id",
                table: "Admins",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfMaterialDetails_BillOfMaterials_BillOfMaterialId",
                table: "BillOfMaterialDetails",
                column: "BillOfMaterialId",
                principalTable: "BillOfMaterials",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfMaterialDetails_Goods_GoodID",
                table: "BillOfMaterialDetails",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_Goods_GoodID",
                table: "Consumptions",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_ProductionOrders_ProductionOrderId",
                table: "Consumptions",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversions_Goods_GoodID",
                table: "Conversions",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_Id",
                table: "Employees",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_BillOfMaterials_ID",
                table: "Goods",
                column: "ID",
                principalTable: "BillOfMaterials",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodShelf_Goods_GoodsID",
                table: "GoodShelf",
                column: "GoodsID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodShelf_Shelves_ShelvesID",
                table: "GoodShelf",
                column: "ShelvesID",
                principalTable: "Shelves",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodSupplier_Goods_MaterialsProducingID",
                table: "GoodSupplier",
                column: "MaterialsProducingID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodSupplier_Suppliers_SuppliersID",
                table: "GoodSupplier",
                column: "SuppliersID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodWarehouse_Goods_GoodsID",
                table: "GoodWarehouse",
                column: "GoodsID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodWarehouse_Warehouses_WarehousesID",
                table: "GoodWarehouse",
                column: "WarehousesID",
                principalTable: "Warehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_Id",
                table: "Managers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Batches_ID",
                table: "ProductionOrders",
                column: "ID",
                principalTable: "Batches",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Goods_GoodId",
                table: "ProductionOrders",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Batches_ID",
                table: "PurchaseOrderDetails",
                column: "ID",
                principalTable: "Batches",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Goods_GoodID",
                table: "PurchaseOrderDetails",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderID",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderID",
                principalTable: "PurchaseOrders",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Warehouses_DestinationWarehouseID",
                table: "PurchaseOrderDetails",
                column: "DestinationWarehouseID",
                principalTable: "Warehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierID",
                table: "PurchaseOrders",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Goods_GoodId",
                table: "Reservations",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_Goods_GoodID",
                table: "SalesOrderDetails",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderID",
                table: "SalesOrderDetails",
                column: "SalesOrderID",
                principalTable: "SalesOrders",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransfers_Goods_GoodId",
                table: "StockTransfers",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryID",
                table: "SubCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_Id",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_BillOfMaterialDetails_BillOfMaterials_BillOfMaterialId",
                table: "BillOfMaterialDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillOfMaterialDetails_Goods_GoodID",
                table: "BillOfMaterialDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Goods_GoodID",
                table: "Consumptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_ProductionOrders_ProductionOrderId",
                table: "Consumptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversions_Goods_GoodID",
                table: "Conversions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Goods_BillOfMaterials_ID",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodShelf_Goods_GoodsID",
                table: "GoodShelf");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodShelf_Shelves_ShelvesID",
                table: "GoodShelf");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodSupplier_Goods_MaterialsProducingID",
                table: "GoodSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodSupplier_Suppliers_SuppliersID",
                table: "GoodSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodWarehouse_Goods_GoodsID",
                table: "GoodWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodWarehouse_Warehouses_WarehousesID",
                table: "GoodWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_Id",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Batches_ID",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrders_Goods_GoodId",
                table: "ProductionOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Batches_ID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Goods_GoodID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Warehouses_DestinationWarehouseID",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierID",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Goods_GoodId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_Goods_GoodID",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderID",
                table: "SalesOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransfers_Goods_GoodId",
                table: "StockTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryID",
                table: "SubCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Goods",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 9, 48, 52, 19, DateTimeKind.Local).AddTicks(2879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 545, DateTimeKind.Local).AddTicks(3811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BillOfMaterials",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 9, 48, 52, 16, DateTimeKind.Local).AddTicks(1807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 543, DateTimeKind.Local).AddTicks(8510));

            migrationBuilder.AlterColumn<int>(
                name: "GoodID",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Batches",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 7, 9, 48, 52, 11, DateTimeKind.Local).AddTicks(428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 7, 22, 29, 27, 541, DateTimeKind.Local).AddTicks(4862));

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_Id",
                table: "Admins",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfMaterialDetails_BillOfMaterials_BillOfMaterialId",
                table: "BillOfMaterialDetails",
                column: "BillOfMaterialId",
                principalTable: "BillOfMaterials",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillOfMaterialDetails_Goods_GoodID",
                table: "BillOfMaterialDetails",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_Goods_GoodID",
                table: "Consumptions",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_ProductionOrders_ProductionOrderId",
                table: "Consumptions",
                column: "ProductionOrderId",
                principalTable: "ProductionOrders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversions_Goods_GoodID",
                table: "Conversions",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_Id",
                table: "Employees",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_BillOfMaterials_ID",
                table: "Goods",
                column: "ID",
                principalTable: "BillOfMaterials",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodShelf_Goods_GoodsID",
                table: "GoodShelf",
                column: "GoodsID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodShelf_Shelves_ShelvesID",
                table: "GoodShelf",
                column: "ShelvesID",
                principalTable: "Shelves",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodSupplier_Goods_MaterialsProducingID",
                table: "GoodSupplier",
                column: "MaterialsProducingID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodSupplier_Suppliers_SuppliersID",
                table: "GoodSupplier",
                column: "SuppliersID",
                principalTable: "Suppliers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodWarehouse_Goods_GoodsID",
                table: "GoodWarehouse",
                column: "GoodsID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodWarehouse_Warehouses_WarehousesID",
                table: "GoodWarehouse",
                column: "WarehousesID",
                principalTable: "Warehouses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_Id",
                table: "Managers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Batches_ID",
                table: "ProductionOrders",
                column: "ID",
                principalTable: "Batches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrders_Goods_GoodId",
                table: "ProductionOrders",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Batches_ID",
                table: "PurchaseOrderDetails",
                column: "ID",
                principalTable: "Batches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Goods_GoodID",
                table: "PurchaseOrderDetails",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderID",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderID",
                principalTable: "PurchaseOrders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Warehouses_DestinationWarehouseID",
                table: "PurchaseOrderDetails",
                column: "DestinationWarehouseID",
                principalTable: "Warehouses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Suppliers_SupplierID",
                table: "PurchaseOrders",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Goods_GoodId",
                table: "Reservations",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_Goods_GoodID",
                table: "SalesOrderDetails",
                column: "GoodID",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_SalesOrders_SalesOrderID",
                table: "SalesOrderDetails",
                column: "SalesOrderID",
                principalTable: "SalesOrders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransfers_Goods_GoodId",
                table: "StockTransfers",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryID",
                table: "SubCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");
        }
    }
}
