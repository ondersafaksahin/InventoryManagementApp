using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs;

namespace InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs
{
    public class InventoryCreateVM
    {
        public float Amount { get; set; }
        public int GoodId { get; set; }
        public int? WarehouseId { get; set; }
        public string? BatchCode { get; set; }
        public DateTime? BatchExpireDate { get; set; }
    }
}
