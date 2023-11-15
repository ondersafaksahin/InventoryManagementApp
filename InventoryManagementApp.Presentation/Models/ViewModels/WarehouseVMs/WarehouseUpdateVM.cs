using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.WarehouseVMs
{
    public class WarehouseUpdateVM
    {
        public Status Status { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public City? City { get; set; }
        public string? District { get; set; }

    }
}
