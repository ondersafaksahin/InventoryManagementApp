﻿using AutoMapper;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
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
            //
            //
            //
            //
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
            //
            //
            //
            //
            //
            //
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
