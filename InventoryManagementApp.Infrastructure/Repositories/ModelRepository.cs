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
    public class ModelRepository : BaseRepository<Model>, IModelRepository
    {
        private readonly InventoryDbContext _dbContext;
        protected DbSet<Model> _modelTable;
        public ModelRepository(InventoryDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._modelTable = _dbContext.Models;
          
        }
    }
}
