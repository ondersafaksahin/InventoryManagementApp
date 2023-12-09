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
    public class InventoryRepository:BaseRepository<Inventory>,IInventoryRepository
    {
        private readonly InventoryDbContext _dbContext;
        public InventoryRepository(InventoryDbContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }

        public override async Task<int> Delete(Inventory item)
        {
            _table.Remove(item);
            await _dbContext.SaveChangesAsync();
            return item.ID;
        }

        public async Task<Inventory> FindMatchingInventory(int goodId, int? warehouseId=null,int? batchId=null)
        {
            var inventory = await _table.FirstOrDefaultAsync(x => x.GoodId == goodId && x.WarehouseId == warehouseId && x.BatchId == batchId);
            return inventory;
        }
    }
}
