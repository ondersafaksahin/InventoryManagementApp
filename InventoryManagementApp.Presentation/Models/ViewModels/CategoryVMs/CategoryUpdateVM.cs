using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs
{
	public class CategoryUpdateVM
	{
        public int ID { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
