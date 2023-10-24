using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.SubCategoryDTOs
{
	public class SubCategoryCreateDTO
	{
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public DateTime? CreatedDate => DateTime.Now;
        public Status Status => Status.Active;

    }
}
