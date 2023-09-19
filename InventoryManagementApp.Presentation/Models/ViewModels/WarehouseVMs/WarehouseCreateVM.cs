using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using Microsoft.CodeAnalysis.Options;

namespace InventoryManagementApp.Presentation.Models.ViewModels.WarehouseVMs
{
    public class WarehouseCreateVM
    {
        //IBaseEntity
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status => Status.Active;


        //IEntity
        public int ID { get; set; }


        //Additional Properties

        public string Name { get; set; }
        public string? Description { get; set; }
        public City? City { get; set; }
        public string? District { get; set; }
      


        //Navigation Properties

        public List<Shelf>? Shelves { get; set; }
        public List<Good>? Goods { get; set; }
    }
}
