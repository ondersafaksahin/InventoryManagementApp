using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs
{
    public class BrandListVM
    {
        public Status Status { get; set; }
        public int ID { get; set; }
        public string BrandName { get; set; }
    }
}
