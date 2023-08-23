using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using InventoryManagementApp.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.Repositories
{
    public class EmployeeRepository : UserBaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(InventoryDbContext DbContext, UserManager<AppUser> userManager) : base(DbContext, userManager)
        {
        }

        public async Task Add(Employee item)
        {
            await _userManager.CreateAsync(item, await GeneratePassword());
            await _dbContext.SaveChangesAsync();
        }
    }
}
