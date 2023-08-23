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
		public BillOfMaterialRepository(InventoryDbContext dbContext) : base(dbContext){}
	}
}
