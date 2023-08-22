using AutoMapper;
using InventoryManagementApp.Application.DTOs.AdminDTOs;
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










            //AppUser












            //Batch










            //BillofMaterial













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
