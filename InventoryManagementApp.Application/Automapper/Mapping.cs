using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
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










            //Brand
            CreateMap<Brand, BrandCreateDTO>().ReverseMap();
            CreateMap<Brand, BrandUpdateDTO>().ReverseMap();
            CreateMap<Brand, BrandListDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            //Category















            //Consumption


















            //Conversion




















            //Customer



























            //Employee


















            //Good
            CreateMap<Good, GoodCreateDTO>().ReverseMap();
            CreateMap<Good, GoodListDTO>().ReverseMap();
            CreateMap<Good, GoodUpdateDTO>().ReverseMap();
            CreateMap<Good, GoodDTO>().ReverseMap();













            //Manager











            //Material















            //Model
            CreateMap<Model, ModelCreateDTO>().ReverseMap();
            CreateMap<Model, ModelListDTO>().ReverseMap();
            CreateMap<Model, ModelUpdateDTO>().ReverseMap();
            CreateMap<Model, ModelDTO>().ReverseMap();
            //Product















            //ProductionOrder













            //PurchaseOrder
            CreateMap<PurchaseOrder, PurchaseOrderCreateDTO>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderDTO>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderListDTO>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderUpdateDTO>().ReverseMap();







            //PurchaseOrderDetails

















            //SalesOrder




















            //SalesOrderDetails















            //Shelf




















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
