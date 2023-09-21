﻿using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.CategoryDTOs
{
	public class CategoryDTO
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
    }
}
