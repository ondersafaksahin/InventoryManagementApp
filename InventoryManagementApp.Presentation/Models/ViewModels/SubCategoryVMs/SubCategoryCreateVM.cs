using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs
{
	public class SubCategoryCreateVM
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status => Status.Active;
        public int CategoryID { get; set; }
        public List<CategoryListDTO>? CategoryList { get; set; }
    }
}
