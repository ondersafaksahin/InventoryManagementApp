using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
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










            //BillofMaterial
            CreateMap<BillOfMaterial, BOMCreateDTO>().ReverseMap();
            CreateMap<BillOfMaterial, BOMUpdateDTO>().ReverseMap();
            CreateMap<BillOfMaterial, BOMListDTO>().ReverseMap();
            CreateMap<BillOfMaterial, BOMDTO>().ReverseMap();
            //BillofMaterialDetails










            //Brand














            //Category















            //Consumption


















            //Conversion




















            //Customer



























            //Employee


















            //Good














            //Manager











            //Material















            //Model













            //Product















            //ProductionOrder













            //PurchaseOrder












            //PurchaseOrderDetails

















            //SalesOrder




















            //SalesOrderDetails















            //Shelf




















            //StockTransfer






















            //SubCategory















            //Supplier
















            //Warehouse



















        }
    }
}
