using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDetailsDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Application.DTOs.CustomerDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
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







            //AppRole






            //AppUser






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

			//Category





			//Consumption





			//Conversion
			CreateMap<Conversion, ConversionCreateDTO>().ReverseMap();
			CreateMap<Conversion, ConversionUpdateDTO>().ReverseMap();
			CreateMap<Conversion, ConversionListDTO>().ReverseMap();
			CreateMap<Conversion, ConversionDTO>().ReverseMap();

			//Customer
			CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerListDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();




            //Employee





            //Good
            CreateMap<Good, GoodCreateDTO>().ReverseMap();
            CreateMap<Good, GoodListDTO>().ReverseMap();
            CreateMap<Good, GoodUpdateDTO>().ReverseMap();
            CreateMap<Good, GoodDTO>().ReverseMap();

            //Manager







            //Model
            CreateMap<Model, ModelCreateDTO>().ReverseMap();
            CreateMap<Model, ModelListDTO>().ReverseMap();
            CreateMap<Model, ModelUpdateDTO>().ReverseMap();
            CreateMap<Model, ModelDTO>().ReverseMap();

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

            //SalesOrder






            //SalesOrderDetails







            //Shelf
            CreateMap<Shelf, ShelfCreateDTO>().ReverseMap();
            CreateMap<Shelf, ShelfUpdateDTO>().ReverseMap();
            CreateMap<Shelf, ShelfListDTO>().ReverseMap();
            CreateMap<Shelf, ShelfDTO>().ReverseMap();


            //StockTransfer







            //SubCategory






            //Supplier







            //Warehouse
            CreateMap<Warehouse, WareHouseCreateDTO>().ReverseMap();
            CreateMap<Warehouse, WareHouseUpdateDTO>().ReverseMap();
            CreateMap<Warehouse, WareHouseListDTO>().ReverseMap();
            CreateMap<Warehouse, WareHouseDTO>().ReverseMap();
        }
    }
}
