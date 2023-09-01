using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDetailsDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.ManagerDTOs;
using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Presentation.Models.ViewModels.BillOfMaterialsDetailsVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.BillOfMaterialsVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ConversionVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ManagerVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ProductionOrderVMs;
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
            //
            //
            //
            //
            //
            //

            //BillofMaterial
            CreateMap<BOMCreateDTO, BillOfMaterialsCreateVM>().ReverseMap();
            CreateMap<BOMUpdateDTO, BillOfMaterialsUpdateVM>().ReverseMap();
            CreateMap<BOMListDTO, BillOfMaterialsListVM>().ReverseMap();
            CreateMap<BOMDTO, BillOfMaterialsVM>().ReverseMap();
            CreateMap<BOMDTO, BillOfMaterialsUpdateVM>().ReverseMap();

            //BillofMaterialDetails
            CreateMap<BillOfMaterialsDetailsCreateDTO, BillOfMaterialsDetailsCreateVM>().ReverseMap();
            CreateMap<BillOfMaterialsDetailsUpdateDTO, BillOfMaterialsDetailsUpdateVM>().ReverseMap();
            CreateMap<BillOfMaterialsDetailsListDTO, BillOfMaterialsDetailsListVM>().ReverseMap();
            CreateMap<BillOfMaterialsDetailsDTO, BillOfMaterialsDetailsVM>().ReverseMap();
            CreateMap<BillOfMaterialsDetailsDTO, BillOfMaterialsDetailsUpdateVM>().ReverseMap();

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
            CreateMap<ConversionCreateDTO, ConversionCreateVM>().ReverseMap();
            CreateMap<ConversionUpdateDTO, ConversionUpdateVM>().ReverseMap();
            CreateMap<ConversionListDTO, ConversionListVM>().ReverseMap();
            CreateMap<ConversionDTO, ConversionVM>().ReverseMap();
            CreateMap<ConversionDTO, ConversionUpdateVM>().ReverseMap();
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
            CreateMap<ManagerCreateDTO, ManagerCreateVM>().ReverseMap();
            CreateMap<ManagerUpdateDTO, ManagerUpdateVM>().ReverseMap();
            CreateMap<ManagerListDTO, ManagerListVM>().ReverseMap();
            CreateMap<ManagerDTO, ManagerVM>().ReverseMap();
            CreateMap<ManagerDTO, ManagerUpdateVM>().ReverseMap();
            //Model
            //
            //
            //
            //
            //
            //
            //
            //ProductionOrder
            CreateMap<ProductionOrderCreateDTO, ProductionOrderCreateVM>().ReverseMap();
            CreateMap<ProductionOrderUpdateDTO, ProductionOrderUpdateVM>().ReverseMap();
            CreateMap<ProductionOrderListDTO, ProductionOrderListVM>().ReverseMap();
            CreateMap<ProductionOrderDTO, ProductionOrderVM>().ReverseMap();
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
