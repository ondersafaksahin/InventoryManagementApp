using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using Microsoft.CodeAnalysis.Options;

namespace InventoryManagementApp.Presentation.Models.ViewModels.WarehouseVMs
{
    public class WarehouseCreateVM
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public City? City { get; set; }
        public string? District { get; set; }
      
    }
}
