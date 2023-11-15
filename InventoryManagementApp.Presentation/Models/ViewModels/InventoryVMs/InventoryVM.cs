using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs
{
    public class InventoryVM
    {
        //IEntity
        public int ID { get; set; }

        //IBaseEntity
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }

        //Additional Properties
        public float Amount { get; set; }

        //Navigation Properties
        public virtual Good Good { get; set; }
        public int GoodId { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public int? WarehouseId { get; set; }
        public Batch? Batch { get; set; }
        public int? BatchId { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
