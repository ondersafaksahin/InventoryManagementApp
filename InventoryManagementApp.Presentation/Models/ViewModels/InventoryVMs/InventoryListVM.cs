using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs
{
    public class InventoryListVM
    {
        public int ID { get; set; }
        public float Amount { get; set; }
        public virtual Good Good { get; set; }
        public int GoodId { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public int? WarehouseId { get; set; }
        public Batch? Batch { get; set; }
        public int? BatchId { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
