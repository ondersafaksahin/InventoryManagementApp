using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Infrastructure.EntitiyMapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.DataAccess
{
    public class InventoryDbContext:IdentityDbContext<AppUser,AppRole,Guid>
	{
        public InventoryDbContext(DbContextOptions options):base(options) { }


        public DbSet<Batch> Batches { get; set; }
        public DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public DbSet<BillOfMaterialDetails> BillOfMaterialDetails { get; set; }
        public DbSet<Brand> Brands{ get; set; }	 
		public DbSet<Category> Categories { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Conversion> Conversions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Good> Goods { get; set; }		 
		public DbSet<Model> Models { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }		 
		public DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }		 
		public DbSet<SalesOrder> SalesOrders { get; set; }		 
		public DbSet<SalesOrderDetails> SalesOrderDetails { get; set; }		 
		public DbSet<Shelf> Shelves { get; set; }		 
		public DbSet<StockTransfer> StockTransfers { get; set; }		 
		public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {

			builder.ApplyConfiguration(new BillOfMaterialMapping());
			builder.ApplyConfiguration(new GoodMapping());
            base.OnModelCreating(builder);

        }

    }
}
