using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs
{
	public class SubCategoryVM
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public List<CategoryListDTO>? CategoryList { get; set; }
    }
}
