using InventoryManagementApp.Domain.IRepositories;
using InventoryManagementApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.Extensions
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddRepositoryServices(this IServiceCollection services) 
		{
			//Önder
			services.AddScoped<IBillOfMaterialRepository, BillOfMaterialRepository>();
			services.AddScoped<IBillOfMaterialDetailsRepository, BillOfMaterialDetailRepository>();
			services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
			services.AddScoped<IConversionRepository, ConversionRepository>();
			services.AddScoped<IProductionOrderRepository, ProductionOrderRepository>();
            //Pelin & Emre
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //Hatice
            services.AddScoped<IBrandRepository, BrandRepository>();
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
