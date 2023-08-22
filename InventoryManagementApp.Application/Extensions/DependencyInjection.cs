using InventoryManagementApp.Application.Services.BatchService;
using InventoryManagementApp.Application.Services.BillOfMaterialsService;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.ModelService;
using InventoryManagementApp.Application.Services.PurchaseOrderDetailService;
using InventoryManagementApp.Application.Services.PurchaseOrderService;
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
            //
            //
            //
            //
            //
            //
            //Pelin
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddScoped<IPurchaseOrderDetailService, PurchaseOrderDetailService>();
            //
            //
            //
            //
            //
            //Emre
            services.AddScoped<IBatchService, BatchService>();
            //
            //
            //
            //
            //
            //
            //Hatice
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();
            //
            //
            //
            //
            //
            //Tolga
            //
            //
            //
            //
            //

            return services;
        }
    }
}
