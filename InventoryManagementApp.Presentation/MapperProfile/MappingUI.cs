using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDetailsDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.ConsumptionDTOs;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Application.DTOs.CustomerDTOs;
using InventoryManagementApp.Application.DTOs.EmployeeDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Application.DTOs.ManagerDTOs;
using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDetailsDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDTOs;
using InventoryManagementApp.Application.DTOs.StockTransferDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Application.DTOs.SupplierDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.BillOfMaterialsDetailsVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.BillOfMaterialsVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ConsumptionVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ConversionVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.CustomerVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.EmployeeVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ManagerVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ProductionOrderVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.PurchaseOrderDetailVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.PurchaseOrderVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SalesOrderDetailsVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SalesOrderVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.StockTransferVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SupplierVMs;
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
            CreateMap<BatchDTO, BatchUpdateVM>().ReverseMap();
            CreateMap<BatchCreateDTO, InventoryCreateVM>().ForMember(x=>x.BatchExpireDate,y=>y.MapFrom(z=>z.ExpireDate)).ReverseMap();
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
            CreateMap<BrandCreateDTO, BrandCreateVM>().ReverseMap();
            CreateMap<BrandUpdateDTO, BrandUpdateVM>().ReverseMap();
            CreateMap<BrandListDTO, BrandListVM>().ReverseMap();
            CreateMap<BrandDTO, BrandVM>().ReverseMap();
            CreateMap<BrandDTO, BrandUpdateVM>().ReverseMap();
            //
            //
            //Category
            CreateMap<CategoryCreateDTO, CategoryCreateVM>().ReverseMap();
            CreateMap<CategoryUpdateDTO, CategoryUpdateVM>().ReverseMap();
            CreateMap<CategoryListDTO, CategoryListVM>().ReverseMap();
            CreateMap<CategoryDTO, CategoryVM>().ReverseMap();
            CreateMap<CategoryDTO, CategoryUpdateVM>().ReverseMap();
            //
            //
            //Consumption
            CreateMap<ConsumptionCreateDTO, ConsumptionCreateVM>().ReverseMap();
            CreateMap<ConsumptionUpdateDTO, ConsumptionUpdateVM>().ReverseMap();
            CreateMap<ConsumptionListDTO, ConsumptionListVM>().ReverseMap();
            CreateMap<ConsumptionDTO, ConsumptionVM>().ReverseMap();
            CreateMap<ConsumptionDTO, ConsumptionUpdateVM>().ReverseMap();
            //
            //Conversion
            CreateMap<ConversionCreateDTO, ConversionCreateVM>().ReverseMap();
            CreateMap<ConversionUpdateDTO, ConversionUpdateVM>().ReverseMap();
            CreateMap<ConversionListDTO, ConversionListVM>().ReverseMap();
            CreateMap<ConversionDTO, ConversionVM>().ReverseMap();
            CreateMap<ConversionDTO, ConversionUpdateVM>().ReverseMap();
            //
            //Customer
            CreateMap<CustomerCreateDTO, CustomerCreateVM>().ReverseMap();
            CreateMap<CustomerUpdateDTO, CustomerUpdateVM>().ReverseMap();
            CreateMap<CustomerListDTO, CustomerListVM>().ReverseMap();
            CreateMap<CustomerDTO, CustomerVM>().ReverseMap();
            CreateMap<CustomerDTO, CustomerUpdateVM>().ReverseMap();
            //
            //
            //Employee
            CreateMap<EmployeeCreateDTO, EmployeeCreateVM>().ReverseMap();
            CreateMap<EmployeeUpdateDTO, EmployeeUpdateVM>().ReverseMap();
            CreateMap<EmployeeListDTO, EmployeeListVM>().ReverseMap();
            CreateMap<EmployeeDTO, EmployeeVM>().ReverseMap();
            CreateMap<EmployeeDTO, EmployeeUpdateVM>().ReverseMap();
            //Good
            CreateMap<GoodCreateDTO, GoodCreateVM>().ReverseMap();
            CreateMap<GoodUpdateDTO, GoodUpdateVM>().ReverseMap();
            CreateMap<GoodListDTO, GoodListVM>().ReverseMap();
            CreateMap<GoodDTO, GoodVM>().ReverseMap();
            CreateMap<GoodDTO, GoodUpdateVM>().ReverseMap();

            //Inventory
            CreateMap< InventoryCreateDTO,  InventoryCreateVM>().ReverseMap();
            CreateMap< InventoryUpdateDTO,  InventoryUpdateVM>().ReverseMap();
            CreateMap< InventoryListDTO,  InventoryListVM>().ReverseMap();
            CreateMap< InventoryDTO,  InventoryVM>().ReverseMap();
            CreateMap< InventoryDTO,  InventoryUpdateVM>().ReverseMap();

            //Manager
            CreateMap<ManagerCreateDTO, ManagerCreateVM>().ReverseMap();
            CreateMap<ManagerUpdateDTO, ManagerUpdateVM>().ReverseMap();
            CreateMap<ManagerListDTO, ManagerListVM>().ReverseMap();
            CreateMap<ManagerDTO, ManagerVM>().ReverseMap();
            CreateMap<ManagerDTO, ManagerUpdateVM>().ReverseMap();
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
            CreateMap<SalesOrderCreateDTO, SalesOrderCreateVM>().ReverseMap();
            CreateMap<SalesOrderUpdateDTO, SalesOrderUpdateVM>().ReverseMap();
            CreateMap<SalesOrderListDTO, SalesOrderListVM>().ReverseMap();
            CreateMap<SalesOrderDTO, SalesOrderVM>().ReverseMap();
            CreateMap<SalesOrderDTO, SalesOrderUpdateVM>().ReverseMap();
            //
            //
            //SalesOrderDetails
            CreateMap<SalesOrdersDetailsCreateDTO, SalesOrderDetailsCreateVM>().ReverseMap();
            CreateMap<SalesOrdersDetailsUpdateDTO, SalesOrderDetailsUpdateVM>().ReverseMap();
            CreateMap<SalesOrdersDetailsListDTO, SalesOrderDetailsListVM>().ReverseMap();
            CreateMap<SalesOrdersDetailsDTO, SalesOrderDetailsVM>().ReverseMap();
            CreateMap<SalesOrdersDetailsDTO, SalesOrderDetailsUpdateVM>().ReverseMap();
            //
            //StockTransfer
            CreateMap<StockTransferCreateDTO, StockTransferCreateVM>().ReverseMap();
            CreateMap<StockTransferUpdateDTO, StockTransferUpdateVM>().ReverseMap();
            CreateMap<StockTransferListDTO, StockTransferListVM>().ReverseMap();
            CreateMap<StockTransferDTO, StockTransferVM>().ReverseMap();
            CreateMap<StockTransferDTO, StockTransferUpdateVM>().ReverseMap();
            //
            //
            //SubCategory
            CreateMap<SubCategoryCreateDTO, SubCategoryCreateVM>().ReverseMap();
            CreateMap<SubCategoryUpdateDTO, SubCategoryUpdateVM>().ReverseMap();
            CreateMap<SubCategoryListDTO, SubCategoryListVM>().ReverseMap();
            CreateMap<SubCategoryDTO, SubCategoryVM>().ReverseMap();
            CreateMap<SubCategoryDTO, SubCategoryUpdateVM>().ReverseMap();
            //
            //
            //Supplier
            CreateMap<SupplierCreateDTO, SupplierCreateVM>().ReverseMap();
            CreateMap<SupplierUpdateDTO, SupplierUpdateVM>().ReverseMap();
            CreateMap<SupplierListDTO, SupplierListVM>().ReverseMap();
            CreateMap<SupplierDTO, SupplierVM>().ReverseMap();
            CreateMap<SupplierDTO, SupplierUpdateVM>().ReverseMap();
            //
            //
            //Warehouse
            CreateMap<WareHouseUpdateDTO, WarehouseUpdateVM>().ReverseMap();
            CreateMap<WareHouseListDTO, WarehouseListVM>().ReverseMap();
            CreateMap<WareHouseCreateDTO, WarehouseCreateVM>().ReverseMap();
            CreateMap<WareHouseDTO, WarehouseVM>().ReverseMap();
            CreateMap<WareHouseDTO, WarehouseUpdateVM>();
            //
            //




        }
    }
}
