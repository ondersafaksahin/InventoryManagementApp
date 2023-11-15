using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs
{
    public class InventoryUpdateVM
    {
        public Status Status { get; set; }
        public float Amount { get; set; }
    }
}
