using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs
{
    public class ShelfUpdateVM
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate = DateTime.Now;
        public Status Status { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }


        //IEntity
        public int ID { get; set; }

        //Additional Properties

        public string Name { get; set; }
        public string? Description { get; set; }

        //Navigation Properties

        public Warehouse? Warehouse { get; set; }
        public int WarehouseID { get; set; }
        public SelectList? WarehouseList { get; set; }
    }
}
