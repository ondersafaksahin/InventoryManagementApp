using InventoryManagementApp.Domain.Entities.Abstract.Classes;
using InventoryManagementApp.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.DataAccess
{
    public class Context:IdentityDbContext<AppUser,AppRole,Guid>
	{
        public DbSet<Batch> Batches { get; set; }
        public DbSet<BillOfMaterial> BillOfMaterials { get; set; }
		public DbSet<Brand> Brands{ get; set; }	 
		public DbSet<Category> Categories { get; set; }
		public DbSet<Company> Companies { get; set; }		 
		public DbSet<Consumption> Consumptions { get; set; }		 
		public DbSet<Material> Materials { get; set; }		 
		public DbSet<Model> Models { get; set; }		 
		public DbSet<Product> Products { get; set; }		 
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }		 
		public DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }		 
		public DbSet<SalesOrder> SalesOrders { get; set; }		 
		public DbSet<SalesOrderDetails> SalesOrderDetails { get; set; }		 
		public DbSet<Shelf> Shelves { get; set; }		 
		public DbSet<StockTransfer> StockTransfers { get; set; }		 
		public DbSet<SubCategory> SubCategories { get; set; }		 
		public DbSet<Warehouse> Warehouses { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
