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
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly InventoryDbContext _dbContext;
        protected DbSet<SubCategory> _subCategoryTable;
        public SubCategoryRepository(InventoryDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._subCategoryTable = _dbContext.SubCategories;

        }
    }
}
