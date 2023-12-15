using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Presentation.Models.ViewModels.StockTransferVMs
{
    public class StockTransferListVM
    {
        public int ID { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public string GoodCode { get; set; }
        public string GoodName { get; set; }
        public int GoodId { get; set; }
        public string? SourceWarehouseName { get; set; }
        public int? SourceWarehouseID { get; set; }
        public string? DestinationWarehouseName { get; set; }
        public int? DestinationWarehouseID { get; set; }
        public string? BatchCode { get; set; }
        public int? BatchId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
