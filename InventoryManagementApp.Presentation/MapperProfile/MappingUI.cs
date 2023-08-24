using AutoMapper;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;

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
            //
            //
            //
            //
            //
            //
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
            //
            //
            //
            //
            //
            //
            //




        }
    }
}
