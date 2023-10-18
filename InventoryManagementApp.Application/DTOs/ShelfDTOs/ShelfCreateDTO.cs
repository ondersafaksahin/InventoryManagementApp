using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.ShelfDTOs
{
    public class ShelfCreateDTO
    {
        public Status Status => Status.Active;
        public string Name { get; set; }
        public string? Description { get; set; }

        public int WarehouseID { get; set; }

        public List<WareHouseListDTO>? WareHouseList { get; set; }
    }
}
