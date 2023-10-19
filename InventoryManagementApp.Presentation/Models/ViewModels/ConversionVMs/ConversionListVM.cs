using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.ConversionVMs
{
    public class ConversionListVM
    {
        public int ID { get; set; }
        public Status Status { get; set; }
        public int GoodID { get; set; }
        public string Good { get; set; }
        public float BaseGoodAmount { get; set; }
        public UnitType BaseUnit { get; set; }
        public float FinalGoodAmount { get; set; }
        public UnitType FinalUnit { get; set; }
    }
}
