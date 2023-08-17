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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly InventoryDbContext _dbContext;
        protected DbSet<Customer> _customerTable;
        public CustomerRepository(InventoryDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._customerTable = _dbContext.Customers;

        }
    }
}
