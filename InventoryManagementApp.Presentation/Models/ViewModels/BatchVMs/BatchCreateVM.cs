using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs
{
    public class BatchCreateVM
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status => Status.Active;

        //IEntity
        public int ID { get; set; }

        //Additional Properties

        public string BatchCode { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        //Navigation Properties

        public Good? Good { get; set; }
        public int? GoodID { get; set; }
        public ProductionOrder? ProductionOrder { get; set; }
        public int? ProductionOrderId { get; set; }
        public PurchaseOrderDetails? PurchaseOrderDetail { get; set; }
        public int? PurchaseOrderDetailId { get; set; }
    }
}
