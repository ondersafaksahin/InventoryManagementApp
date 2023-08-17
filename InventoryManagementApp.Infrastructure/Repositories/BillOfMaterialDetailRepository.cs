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
		public BillOfMaterialDetailRepository(InventoryDbContext DbContext) : base(DbContext){}
	}
}
