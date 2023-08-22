using InventoryManagementApp.Application.DTOs.AdminDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.AdminService
{
    public interface IAdminService:IBaseService<AdminCreateDTO,AdminUpdateDTO,AdminListDTO,AdminDTO,Admin,Guid>
    {
    }
}
