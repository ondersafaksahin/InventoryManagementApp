using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.CategoryDTOs
{
	public class CategoryUpdateDTO
	{
        public int ID { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
