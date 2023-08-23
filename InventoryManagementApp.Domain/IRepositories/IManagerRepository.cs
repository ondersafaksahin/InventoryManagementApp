using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.IRepositories
{
    public interface IManagerRepository: IUserBaseRepository<Manager>
    {
        Task Add(Manager item);
    }
}
