using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs
{
    public class GoodListVM
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string? ModelCode { get; set; }
        public string Name { get; set; }
        public float StockAmount { get; set; }
        public float? ReservedStock { get; set; }
        public float? MinStock { get; set; }
        public decimal? ListPrice { get; set; }
        public string? Barcode { get; set; }
        

        public Status Status { get; set; }
    }
}
