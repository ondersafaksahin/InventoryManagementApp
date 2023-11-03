using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs
{
	public class SubCategoryUpdateVM
	{
        public int ID { get; set; }
        public Status Status { get; set; }
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public SelectList? CategoryList { get; set; }
    }
}
