using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs
{
	public class SubCategoryUpdateVM
	{
        public Status Status { get; set; }
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public List<CategoryListDTO>? CategoryList { get; set; }
    }
}
