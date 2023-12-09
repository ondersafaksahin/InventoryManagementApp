using InventoryManagementApp.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Models.ViewModels.StockTransferVMs
{
    public class StockTransferCreateVM
    {
        public float Amount { get; set; }
        public string? Description { get; set; }
        public int GoodId { get; set; }
        public int SourceWarehouseID { get; set; }
        public int DestinationWarehouseID { get; set; }
        public int? BatchId { get; set; }
        public SelectList? GoodsList { get; set; }
        public SelectList? WarehouseList { get; set; }
    }
}
