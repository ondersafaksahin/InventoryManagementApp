using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs
{
    public class ShelfCreateVM
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }


        //Additional Properties
        public int ID { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        //Navigation Properties

        public Warehouse? Warehouse { get; set; }
        public int WarehouseID { get; set; }

        public List<Good>? Goods { get; set; }
    }
}
