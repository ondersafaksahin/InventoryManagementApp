using InventoryManagementApp.Application.DTOs.ManagerDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ManagerService
{
    public interface IManagerService:IBaseService<ManagerCreateDTO,ManagerUpdateDTO,ManagerListDTO,ManagerDTO,Manager,Guid>
    {
    }
}
