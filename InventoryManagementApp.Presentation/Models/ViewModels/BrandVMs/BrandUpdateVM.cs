using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs
{
    public class BrandUpdateVM
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public Status Status { get; set; }
    }
}
