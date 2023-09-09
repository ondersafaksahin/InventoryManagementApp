using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs
{
	public class CategoryCreateVM
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status => Status.Active;
    }
}
