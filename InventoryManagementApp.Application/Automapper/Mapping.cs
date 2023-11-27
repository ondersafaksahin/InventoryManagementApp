using AutoMapper;
using InventoryManagementApp.Application.DTOs.AdminDTOs;
using InventoryManagementApp.Application.DTOs.AppRoleDTOs;
using InventoryManagementApp.Application.DTOs.AppUserDTOs;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDetailsDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.ConsumptionDTOs;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Application.DTOs.CustomerDTOs;
using InventoryManagementApp.Application.DTOs.DeliveryDetailDTOs;
using InventoryManagementApp.Application.DTOs.DeliveryDTOs;
using InventoryManagementApp.Application.DTOs.EmployeeDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.GoodsReceiptDetailDTOs;
using InventoryManagementApp.Application.DTOs.GoodsReceiptDTOs;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Application.DTOs.ManagerDTOs;
using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.ReservationDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDetailsDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDTOs;
using InventoryManagementApp.Application.DTOs.StockTransferDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Application.DTOs.SupplierDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Automapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            //Admin
            CreateMap<Admin, AdminCreateDTO>().ReverseMap();
            CreateMap<Admin, AdminDTO>().ReverseMap();
            CreateMap<Admin, AdminListDTO>().ReverseMap();
            CreateMap<Admin, AdminUpdateDTO>().ReverseMap();



            //AppRole
            CreateMap<AppRole, AppRoleCreateDTO>().ReverseMap();
            CreateMap<AppRole, AppRoleListDTO>().ReverseMap();
            CreateMap<AppRole, AppRoleUpdateDTO>().ReverseMap();
            CreateMap<AppUser, RoleAssignDTO>().ReverseMap();


            //AppUser
            CreateMap<AppUser, LoginDTO>().ReverseMap();





            //Batch
            CreateMap<Batch, BatchCreateDTO>().ReverseMap();
            CreateMap<Batch, BatchUpdateDTO>().ReverseMap();
            CreateMap<Batch, BatchListDTO>().ReverseMap();
            CreateMap<Batch, BatchDTO>().ReverseMap();

            //BillofMaterial
            CreateMap<BillOfMaterial, BOMCreateDTO>().ReverseMap();
            CreateMap<BillOfMaterial, BOMUpdateDTO>().ReverseMap();
            CreateMap<BillOfMaterial, BOMListDTO>().ReverseMap();
            CreateMap<BillOfMaterial, BOMDTO>().ReverseMap();

            //BillofMaterialDetails
			CreateMap<BillOfMaterialDetails, BillOfMaterialsDetailsCreateDTO>().ReverseMap();
			CreateMap<BillOfMaterialDetails, BillOfMaterialsDetailsUpdateDTO>().ReverseMap();
			CreateMap<BillOfMaterialDetails, BillOfMaterialsDetailsListDTO>().ReverseMap();
			CreateMap<BillOfMaterialDetails, BillOfMaterialsDetailsDTO>().ReverseMap();

			//Brand
			CreateMap<Brand, BrandCreateDTO>().ReverseMap();
            CreateMap<Brand, BrandUpdateDTO>().ReverseMap();
            CreateMap<Brand, BrandListDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<BrandDTO, BrandUpdateDTO>().ReverseMap();

            //Category
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
			CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
			CreateMap<Category, CategoryListDTO>().ReverseMap();
			CreateMap<Category, CategoryDTO>().ReverseMap();

			//Consumption
			CreateMap<Consumption, ConsumptionCreateDTO>().ReverseMap();
			CreateMap<Consumption, ConsumptionUpdateDTO>().ReverseMap();
			CreateMap<Consumption, ConsumptionListDTO>().ReverseMap();
			CreateMap<Consumption, ConsumptionDTO>().ReverseMap();

			//Conversion
			CreateMap<Conversion, ConversionCreateDTO>().ReverseMap();
			CreateMap<Conversion, ConversionUpdateDTO>().ReverseMap();
			CreateMap<Conversion, ConversionListDTO>().ReverseMap();
			CreateMap<Conversion, ConversionDTO>().ReverseMap();
            CreateMap<ConversionUpdateDTO, ConversionDTO>().ReverseMap();

            //Customer
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerListDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();




            //Employee
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeListDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            //Good
            CreateMap<Good, GoodCreateDTO>().ReverseMap();
            CreateMap<Good, GoodListDTO>().ReverseMap();
            CreateMap<Good, GoodUpdateDTO>().ReverseMap();
            CreateMap<Good, GoodDTO>().ReverseMap();
            CreateMap<GoodDTO, GoodUpdateDTO>().ReverseMap();

            //Inventory
            CreateMap<Inventory, InventoryCreateDTO>().ReverseMap();
            CreateMap<Inventory, InventoryUpdateDTO>().ReverseMap();
            CreateMap<Inventory, InventoryListDTO>().ReverseMap();
            CreateMap<Inventory, InventoryDTO>().ReverseMap();
            CreateMap<InventoryUpdateDTO, InventoryDTO>().ReverseMap();
            CreateMap<InventoryDTO, InventoryCreateDTO>().ReverseMap();

            //Manager
            CreateMap<Manager, ManagerCreateDTO>().ReverseMap();
            CreateMap<Manager, ManagerDTO>().ReverseMap();
            CreateMap<Manager, ManagerListDTO>().ReverseMap();
            CreateMap<Manager, ManagerUpdateDTO>().ReverseMap();


			//ProductionOrder
			CreateMap<ProductionOrder, ProductionOrderCreateDTO>().ReverseMap();
			CreateMap<ProductionOrder, ProductionOrderListDTO>().ReverseMap();
			CreateMap<ProductionOrder, ProductionOrderUpdateDTO>().ReverseMap();
			CreateMap<ProductionOrder, ProductionOrderDTO>().ReverseMap();

			//PurchaseOrder
			CreateMap<PurchaseOrder, PurchaseOrderCreateDTO>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderDTO>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderListDTO>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderUpdateDTO>().ReverseMap();

            //PurchaseOrderDetails
            CreateMap<PurchaseOrderDetails, PurchaseOrderDetailCreateDTO>().ReverseMap();
            CreateMap<PurchaseOrderDetails, PurchaseOrderDetailUpdateDTO>().ReverseMap();
            CreateMap<PurchaseOrderDetails, PurchaseOrderDetailListDTO>().ReverseMap();
            CreateMap<PurchaseOrderDetails, PurchaseOrderDetailDTO>().ReverseMap();

			//Reservation
			CreateMap<Reservation, ReservationCreateDTO>().ReverseMap();
			CreateMap<Reservation, ReservationUpdateDTO>().ReverseMap();
			CreateMap<Reservation, ReservationListDTO>().ReverseMap();
			CreateMap<Reservation, ReservationDTO>().ReverseMap();

			//SalesOrder
			CreateMap<SalesOrder, SalesOrderCreateDTO>().ReverseMap();
            CreateMap<SalesOrder, SalesOrderUpdateDTO>().ReverseMap();
            CreateMap<SalesOrder, SalesOrderListDTO>().ReverseMap();
            CreateMap<SalesOrder, SalesOrderDTO>().ReverseMap();


            //SalesOrderDetails
            CreateMap<SalesOrderDetails, SalesOrdersDetailsCreateDTO>().ReverseMap();
            CreateMap<SalesOrderDetails, SalesOrdersDetailsUpdateDTO>().ReverseMap();
            CreateMap<SalesOrderDetails, SalesOrdersDetailsListDTO>().ReverseMap();
            CreateMap<SalesOrderDetails, SalesOrdersDetailsDTO>().ReverseMap();


            //StockTransfer
            CreateMap<StockTransfer, StockTransferCreateDTO>().ReverseMap();
            CreateMap<StockTransfer, StockTransferUpdateDTO>().ReverseMap();
            CreateMap<StockTransfer, StockTransferListDTO>().ReverseMap();
            CreateMap<StockTransfer, StockTransferDTO>().ReverseMap();



			//SubCategory
			CreateMap<SubCategory, SubCategoryCreateDTO>().ReverseMap();
			CreateMap<SubCategory, SubCategoryUpdateDTO>().ReverseMap();
			CreateMap<SubCategory, SubCategoryListDTO>().ReverseMap();
			CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<SubCategoryDTO, SubCategoryUpdateDTO>().ReverseMap();


            //Supplier
            CreateMap<Supplier, SupplierCreateDTO>().ReverseMap();
			CreateMap<Supplier, SupplierUpdateDTO>().ReverseMap();
			CreateMap<Supplier, SupplierListDTO>().ReverseMap();
			CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<SupplierUpdateDTO, SupplierDTO>().ReverseMap();

            //Warehouse
            CreateMap<Warehouse, WareHouseCreateDTO>().ReverseMap();
            CreateMap<Warehouse, WareHouseUpdateDTO>().ReverseMap();
            CreateMap<Warehouse, WareHouseListDTO>().ReverseMap();
            CreateMap<Warehouse, WareHouseDTO>().ReverseMap();

            //Delivery
            CreateMap<Delivery, DeliveryCreateDTO>().ReverseMap();
            CreateMap<Delivery, DeliveryUpdateDTO>().ReverseMap();
            CreateMap<Delivery, DeliveryListDTO>().ReverseMap();
            CreateMap<Delivery, DeliveryDTO>().ReverseMap();

            //DeliveryDetail
            CreateMap<DeliveryDetail, DeliveryDetailCreateDTO>().ReverseMap();
            CreateMap<DeliveryDetail, DeliveryDetailUpdateDTO>().ReverseMap();
            CreateMap<DeliveryDetail, DeliveryDetailListDTO>().ReverseMap();
            CreateMap<DeliveryDetail, DeliveryDetailDTO>().ReverseMap();

            //GoodsReceipt
            CreateMap<GoodsReceipt, GoodsReceiptCreateDTO>().ReverseMap();
            CreateMap<GoodsReceipt, GoodsReceiptUpdateDTO>().ReverseMap();
            CreateMap<GoodsReceipt, GoodsReceiptListDTO>().ReverseMap();
            CreateMap<GoodsReceipt, GoodsReceiptDTO>().ReverseMap();

            //GoodsReceiptDetail
            CreateMap<GoodsReceiptDetail, GoodsReceiptDetailCreateDTO>().ReverseMap();
            CreateMap<GoodsReceiptDetail, GoodsReceiptDetailUpdateDTO>().ReverseMap();
            CreateMap<GoodsReceiptDetail, GoodsReceiptDetailListDTO>().ReverseMap();
            CreateMap<GoodsReceiptDetail, GoodsReceiptDetailDTO>().ReverseMap();

        }
    }
}
