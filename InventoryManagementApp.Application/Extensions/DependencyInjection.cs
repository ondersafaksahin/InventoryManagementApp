using InventoryManagementApp.Application.Services.BillOfMaterialsService;
using InventoryManagementApp.Application.Services.GoodService;
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
            //
            //
            //
            //
            //
            //
            //
            //
            //Emre
            //
            //
            //
            //
            //
            //
            //
            //Hatice
            //
            //
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
