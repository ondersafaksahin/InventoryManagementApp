using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.WareHouseService
{
    public interface IWareHouseService : IBaseService<WareHouseCreateDTO, WareHouseUpdateDTO, WareHouseListDTO, WareHouseDTO, Warehouse, int>
    {
        
    }
}
