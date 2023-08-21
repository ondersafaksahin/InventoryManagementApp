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
    public class ShelfRepository : BaseRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(InventoryDbContext DbContext) : base(DbContext)
        {
        }
    }
}
