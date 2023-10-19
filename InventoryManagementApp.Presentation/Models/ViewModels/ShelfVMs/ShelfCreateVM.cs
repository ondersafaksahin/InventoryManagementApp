using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs
{
    public class ShelfCreateVM
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int WarehouseID { get; set; }
        public List<WareHouseListDTO>? WareHouseList { get; set; }

    }
}
