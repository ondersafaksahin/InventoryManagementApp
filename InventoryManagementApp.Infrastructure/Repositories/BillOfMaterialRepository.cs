using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using InventoryManagementApp.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.Repositories
{
	public class BillOfMaterialRepository : BaseRepository<BillOfMaterial>, IBillOfMaterialRepository
	{
		InventoryDbContext _database;
		DbSet<BillOfMaterial> _billOfMaterialsTable;

		public BillOfMaterialRepository(InventoryDbContext DbContext) : base(DbContext)
		{
			_database = DbContext;
			_billOfMaterialsTable = _database.BillOfMaterials;
		}
	}
}
