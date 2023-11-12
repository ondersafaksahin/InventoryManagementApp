using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.InventoryService
{
    public interface IInventoryService:IBaseService<InventoryCreateDTO,InventoryUpdateDTO,InventoryListDTO,InventoryDTO,Inventory,int>
    {
    }
}
