using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs
{
    public class BatchCreateVM
    {
        public string BatchCode { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? GoodReceiptDetailId { get; set; }
    }
}
