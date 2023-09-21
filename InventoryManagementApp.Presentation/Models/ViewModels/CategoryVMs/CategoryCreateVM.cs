using InventoryManagementApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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
