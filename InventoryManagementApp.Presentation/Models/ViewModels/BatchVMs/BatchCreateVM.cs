using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs
{
    public class BatchCreateVM
    {
        public string? BatchCode { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        //Navigation Properties

        public ProductionOrder? ProductionOrder { get; set; }
        public int? ProductionOrderId { get; set; }
        public PurchaseOrderDetails? PurchaseOrderDetail { get; set; }
        public int? PurchaseOrderDetailId { get; set; }
    }
}
