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
			services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
			//Pelin & Emre
			services.AddScoped<IGoodRepository, GoodRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderDetailsRepository, PurchaseOrderDetailsRepository>();
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<ISalesOrderDetailsRepository, SalesOrderDetailsRepository>();
            services.AddScoped<IStockTransferRepository, StockTransferRepository>();
            services.AddScoped<IWareHouseRepository, WareHouseRepository>();
            //
            //
            //Hatice
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IDeliveryDetailRepository, DeliveryDetailRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IGoodsReceiptRepository, GoodsReceiptRepository>();
            services.AddScoped<IGoodsReceiptDetailRepository, GoodsReceiptDetailRepository>();
            //Tolga
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //
            //

            return services;
		}
	}
}
