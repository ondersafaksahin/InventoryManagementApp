﻿using InventoryManagementApp.Application.Services.AdminService;
using InventoryManagementApp.Application.Services.AppRoleService;
using InventoryManagementApp.Application.Services.AppUserService;
using InventoryManagementApp.Application.Services.BatchService;
using InventoryManagementApp.Application.Services.BillOfMaterialsDetailsService;
using InventoryManagementApp.Application.Services.BillOfMaterialsService;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Application.Services.ConsumpitonService;
using InventoryManagementApp.Application.Services.ConversionService;
using InventoryManagementApp.Application.Services.CustomerService;
using InventoryManagementApp.Application.Services.EmployeeService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.ManagerService;
using InventoryManagementApp.Application.Services.ModelService;
using InventoryManagementApp.Application.Services.ProductionOrderService;
using InventoryManagementApp.Application.Services.PurchaseOrderDetailService;
using InventoryManagementApp.Application.Services.PurchaseOrderService;
using InventoryManagementApp.Application.Services.SalesOrdersDetailsService;
using InventoryManagementApp.Application.Services.SalesOrderService;
using InventoryManagementApp.Application.Services.ShelfService;
using InventoryManagementApp.Application.Services.StockTransferService;
using InventoryManagementApp.Application.Services.SubCategoryService;
using InventoryManagementApp.Application.Services.SupplierService;
using InventoryManagementApp.Application.Services.WareHouseService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //Önder
            services.AddScoped<IBillOfMatieralsService, BillOfMatieralsService>();
			services.AddScoped<IProductionOrderService, ProductionOrderService>();
			services.AddScoped<IBillOfMaterialsDetailsService, BillOfMaterialsDetailsService>();
			services.AddScoped<IConversionService, ConversionService>();
			services.AddScoped<IConsumptionService, ConsumptionService>();
			//Pelin
			services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddScoped<IPurchaseOrderDetailService, PurchaseOrderDetailService>();
            services.AddScoped<IShelfService, ShelfService>();
            //
            //
            //
            //
            //Emre
            services.AddScoped<IBatchService, BatchService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<ISalesOrdersDetailsService, SalesOrdersDetailsService>();
            services.AddScoped<IStockTransferService, StockTransferService>();
            //
            //
            //
            //Hatice
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<ISupplierService, SupplierService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ISubCategoryService, SubCategoryService>();
			//
			//Tolga
			services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppRoleService, AppRoleService>();

            return services;
        }
    }
}
