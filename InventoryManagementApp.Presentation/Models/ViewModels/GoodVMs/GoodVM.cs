using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs
{
    public class GoodVM
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string? ModelCode { get; set; }
        public string Name { get; set; }
        public string? Picture { get; set; }
        public UnitType? StockingUnit { get; set; }
        public UnitType? ConsumptionUnit { get; set; }
        public byte? TaxPercentage { get; set; }
        public decimal? ListPrice { get; set; }
        public CurrencyCodes? ListCurrency { get; set; }
        public string? Barcode { get; set; }
        public float? GrossWeight { get; set; }
        public float? NetWeight { get; set; }
        public int? CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public int? ModelID { get; set; }
        public int? BrandID { get; set; }
        public int? BillOfMaterialID { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
