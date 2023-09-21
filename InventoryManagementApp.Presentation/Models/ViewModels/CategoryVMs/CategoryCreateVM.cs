﻿using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs
{
	public class CategoryCreateVM
	{
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public Status Status => Status.Active;

    }
}
