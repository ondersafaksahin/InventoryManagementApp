using InventoryManagementApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs
{
	public class CategoryCreateVM
	{
        public string Name { get; set; }

        [StringLength(25)]
        public string? Description { get; set; }
        public Status Status => Status.Active;
    }
}
