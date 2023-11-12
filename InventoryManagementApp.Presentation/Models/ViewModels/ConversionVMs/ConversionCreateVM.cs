using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Models.ViewModels.ConversionVMs
{
    public class ConversionCreateVM
    {
        public SelectList? GoodsList { get; set; }
        public int GoodID { get; set; }
        public float BaseGoodAmount { get; set; }
        public UnitType BaseUnit { get; set; }
        public float FinalGoodAmount { get; set; }
        public UnitType FinalUnit { get; set; }
    }
}
