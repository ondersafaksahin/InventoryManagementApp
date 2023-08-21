using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using InventoryManagementApp.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.Repositories
{
    public class WareHouseRepository : BaseRepository<Warehouse>, IWareHouseRepository
    {
        public WareHouseRepository(InventoryDbContext DbContext) : base(DbContext)
        {
        }
    }
}
