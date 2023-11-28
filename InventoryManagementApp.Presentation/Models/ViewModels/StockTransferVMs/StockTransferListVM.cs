using InventoryManagementApp.Domain.Entities.Concrete;

namespace InventoryManagementApp.Presentation.Models.ViewModels.StockTransferVMs
{
    public class StockTransferListVM
    {
        public int ID { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public virtual Good Good { get; set; }
        public int GoodId { get; set; }
        public Warehouse? SourceWarehouse { get; set; }
        public int? SourceWarehouseID { get; set; }
        public Warehouse? DestinationWarehouse { get; set; }
        public int? DestinationWarehouseID { get; set; }
    }
}
