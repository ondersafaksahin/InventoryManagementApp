using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs
{
    public class ShelfCreateVM
    {
        public Status Status => Status.Active;
        public string Name { get; set; }
        public string? Description { get; set; }

        public int WarehouseID { get; set; }

        public List<WareHouseListDTO>? WareHouseList { get; set; }

    }
}
