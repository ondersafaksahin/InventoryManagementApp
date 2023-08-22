using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using InventoryManagementApp.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.Repositories
{
    public class AdminRepository : UserBaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(InventoryDbContext DbContext, UserManager<AppUser> userManager) : base(DbContext, userManager)
        {
        }

        public async Task Add(Admin item)
        {
            await _userManager.CreateAsync(item, await GeneratePassword());
            await _dbContext.SaveChangesAsync();
        }
    }
}
