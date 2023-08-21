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
    public class PurchaseOrderDetailsRepository : BaseRepository<PurchaseOrderDetails>, IPurchaseOrderDetailsRepository
    {
        public PurchaseOrderDetailsRepository(InventoryDbContext DbContext) : base(DbContext)
        {
        }
    }
}
