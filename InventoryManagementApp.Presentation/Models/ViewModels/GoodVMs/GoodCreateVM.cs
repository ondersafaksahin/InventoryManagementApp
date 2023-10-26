using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs
{
    public class GoodCreateVM
    {
        [MaxLength(40,ErrorMessage ="Character limit for code is 40")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Picture { get; set; }
        public float StockAmount { get; set; }
        public float? ReservedStock { get; set; }
        public UnitType? StockingUnit { get; set; }
        public UnitType? ConsumptionUnit { get; set; }
        public float? MinStock { get; set; }
        public byte? TaxPercentage { get; set; }
        public decimal? ListPrice { get; set; }
        public string? Barcode { get; set; }
        public float? GrossWeight { get; set; }
        public float? NetWeight { get; set; }
        public int? CategoryID { get; set; }
        public List<CategoryListDTO>? CategoryList { get; set; }
        public int? SubCategoryID { get; set; }
        public List<SubCategoryListDTO>? SubCategoryList { get; set; }
        public int? ModelID { get; set; }
        public List<ModelListDTO>? ModelList { get; set; }
        public int? BrandID { get; set; }
        public List<BrandListDTO>? BrandList { get; set; }
        public BillOfMaterial? BillOfMaterial { get; set; }
        public int? BillOfMaterialID { get; set; }

        
    }
}
