using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.IRepositories
{
    public interface IInventoryRepository:IBaseRepository<Inventory>
    {
        public Task<Inventory> FindMatchingInventory(int goodId, int? warehouseId=null, int? batchId = null);
    }
}
