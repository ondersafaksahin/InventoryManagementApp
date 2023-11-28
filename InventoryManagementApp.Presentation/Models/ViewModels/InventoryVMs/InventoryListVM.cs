using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs
{
    public class InventoryListVM
    {
        public int ID { get; set; }
        public float Amount { get; set; }
        public string GoodName { get; set; }
        public int GoodId { get; set; }
        public string? WarehouseName { get; set; }
        public int? WarehouseId { get; set; }
        public string? BatchCode { get; set; }
        public int? BatchId { get; set; }
    }
}
