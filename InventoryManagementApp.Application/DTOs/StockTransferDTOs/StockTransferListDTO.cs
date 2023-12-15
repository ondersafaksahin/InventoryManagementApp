using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Application.DTOs.StockTransferDTOs
{
    public class StockTransferListDTO
    {
        public int ID { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public virtual Good Good { get; set; }
        public int GoodId { get; set; }
        public Warehouse? SourceWarehouse { get; set; }
        public int? SourceWarehouseID { get; set; }
        public Warehouse? DestinationWarehouse { get; set; }
        public int? DestinationWarehouseID { get; set; }
        public Batch? Batch { get; set; }
        public int? BatchId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
