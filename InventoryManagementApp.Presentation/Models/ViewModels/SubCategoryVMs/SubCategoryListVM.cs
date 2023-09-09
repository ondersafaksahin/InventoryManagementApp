﻿using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;

namespace InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs
{
	public class SubCategoryListVM
	{
        public int ID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public List<CategoryListDTO>? CategoryList { get; set; }
    }
}
