﻿using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.PurchaseOrderDetailVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.PurchaseOrderVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.WarehouseVMs;

namespace InventoryManagementApp.Presentation.MapperProfile
{
    public class MappingUI:Profile
    {
        public MappingUI()
        {

            //Admin
            //
            //
            //
            //
            //
            //
            //
            //AppRole
            //
            //
            //
            //
            //
            //
            //
            //AppUser
            //
            //
            //
            //
            //
            //
            //
            //Batch
            CreateMap<BatchCreateDTO, BatchCreateVM>().ReverseMap();
            CreateMap<BatchUpdateDTO, BatchUpdateVM>().ReverseMap();
            CreateMap<BatchListDTO, BatchListVM>().ReverseMap();
            CreateMap<BatchDTO, BatchVM>().ReverseMap();
            //
            //
            //
            //BillofMaterial
            //
            //
            //
            //
            //
            //
            //
            //BillofMaterialDetails
            //
            //
            //
            //
            //
            //
            //
            //Brand
            //
            //
            //
            //
            //
            //
            //
            //Category
            //
            //
            //
            //
            //
            //
            //
            //Consumption
            //
            //
            //
            //
            //
            //
            //
            //Conversion
            //
            //
            //
            //
            //
            //
            //
            //Customer
            //
            //
            //
            //
            //
            //
            //
            //Employee
            //
            //
            //
            //
            //
            //
            //
            //Good
            CreateMap<GoodCreateDTO, GoodCreateVM>().ReverseMap();
            CreateMap<GoodUpdateDTO, GoodUpdateVM>().ReverseMap();
            CreateMap<GoodListDTO, GoodListVM>().ReverseMap();
            CreateMap<GoodDTO, GoodVM>().ReverseMap();
            //
            //Manager
            //
            //
            //
            //
            //
            //
            //
            //Model
            //
            //
            //
            //
            //
            //
            //
            //ProductionOrder
            //
            //
            //
            //
            //
            //
            //
            //PurchaseOrder
            CreateMap<PurchaseOrderCreateDTO, PurchaseOrderCreateVM>().ReverseMap();
            CreateMap<PurchaseOrderUpdateDTO, PurchaseOrderUpdateVM>().ReverseMap();
            CreateMap<PurchaseOrderListDTO, PurchaseOrderListVM>().ReverseMap();
            CreateMap<PurchaseOrderDTO, PurchaseOrderVM>().ReverseMap();
            //
            //PurchaseOrderDetails
            CreateMap<PurchaseOrderDetailUpdateDTO, PurchaseOrderDetailUpdateVM>().ReverseMap();
            CreateMap<PurchaseOrderDetailCreateDTO, PurchaseOrderDetailCreateVM>().ReverseMap();
            CreateMap<PurchaseOrderDetailListDTO, PurchaseOrderListVM>().ReverseMap();
            CreateMap<PurchaseOrderDetailDTO, PurchaseOrderDetailVM>().ReverseMap();
            //
            //ReservedStock
            //
            //
            //
            //
            //
            //
            //
            //SalesOrder
            //
            //
            //
            //
            //
            //
            //
            //SalesOrderDetails
            //
            //
            //
            //
            //
            //
            //
            //Shelf
            CreateMap<ShelfCreateDTO, ShelfCreateVM>().ReverseMap();
            CreateMap<ShelfUpdateDTO, ShelfUpdateVM>().ReverseMap();
            CreateMap<ShelfListDTO, ShelfListVM>().ReverseMap();
            CreateMap<ShelfDTO, ShelfVM>().ReverseMap();
            //
            //StockTransfer
            //
            //
            //
            //
            //
            //
            //
            //SubCategory
            //
            //
            //
            //
            //
            //
            //
            //Supplier
            //
            //
            //
            //
            //
            //
            //
            //Warehouse
            CreateMap<WareHouseUpdateDTO, WarehouseUpdateVM>().ReverseMap();
            CreateMap<WareHouseListDTO, WarehouseListVM>().ReverseMap();
            CreateMap<WareHouseCreateDTO, WarehouseCreateVM>().ReverseMap();
            CreateMap<WareHouseDTO, WarehouseVM>().ReverseMap();
            //
            //
            //




        }
    }
}
