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
			//
			//
			//
			//
			//
			//
			//
			//
			//Pelin
			//
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
