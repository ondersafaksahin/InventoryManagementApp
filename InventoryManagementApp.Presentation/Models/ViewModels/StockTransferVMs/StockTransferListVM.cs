using InventoryManagementApp.Domain.Entities.Concrete;

namespace InventoryManagementApp.Presentation.Models.ViewModels.StockTransferVMs
{
    public class StockTransferListVM
    {
        public int ID { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public string GoodName { get; set; }
        public int GoodId { get; set; }
        public string? SourceWarehouseName { get; set; }
        public int? SourceWarehouseID { get; set; }
        public string? DestinationWarehouseName { get; set; }
        public int? DestinationWarehouseID { get; set; }
    }
}
