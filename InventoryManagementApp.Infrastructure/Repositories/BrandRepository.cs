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
    public class BrandRepository:BaseRepository<Brand>,IBrandRepository
    {
        private readonly InventoryDbContext _dbContext;
        protected DbSet<Brand> _brandTable;
        public BrandRepository(InventoryDbContext dbContext):base(dbContext)
        {
            this._dbContext = dbContext;
            this._brandTable = _dbContext.Brands;
        }
    }
}
