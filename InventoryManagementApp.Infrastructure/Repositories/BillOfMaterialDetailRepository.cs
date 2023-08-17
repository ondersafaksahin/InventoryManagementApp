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
	public class BillOfMaterialDetailRepository : BaseRepository<BillOfMaterialDetails>, IBillOfMaterialDetailsRepository
	{
		InventoryDbContext _database;
		DbSet<BillOfMaterialDetails> _BomTable;
		public BillOfMaterialDetailRepository(InventoryDbContext DbContext) : base(DbContext)
		{
			_database = DbContext;
			_BomTable = _database.BillOfMaterialDetails;
		}
	}
}
