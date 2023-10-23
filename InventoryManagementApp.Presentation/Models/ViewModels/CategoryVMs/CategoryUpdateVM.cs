using InventoryManagementApp.Domain.Enums;
using InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs;

namespace InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs
{
	public class CategoryUpdateVM
	{
        public int ID { get; set; }
        public Status Status { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        //Navigation Properties
        public SubCategoryCreateVM? newSubCategory { get; set; }
    }
}
