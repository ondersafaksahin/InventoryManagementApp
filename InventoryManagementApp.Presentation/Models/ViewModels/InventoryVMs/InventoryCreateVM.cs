using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs
{
    public class InventoryCreateVM
    {
        public float Amount { get; set; }
        public int GoodId { get; set; }
        public int? WarehouseId { get; set; }
    }
}
