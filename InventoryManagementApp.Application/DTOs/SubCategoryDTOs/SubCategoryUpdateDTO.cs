﻿using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.SubCategoryDTOs
{
	public class SubCategoryUpdateDTO
	{
        public int ID { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; }
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
