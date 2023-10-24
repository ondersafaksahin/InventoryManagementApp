using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs
{
	public class SubCategoryVM
	{
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public SelectList? CategoryList { get; set; }
    }
}
