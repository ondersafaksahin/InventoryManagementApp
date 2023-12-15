using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.StockTransferDTOs
{
    public class StockTransferCreateDTO
    {
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
        public float Amount { get; set; }
        public string? Description { get; set; }
        public int GoodId { get; set; }
        public int? SourceWarehouseID { get; set; }
        public int? DestinationWarehouseID { get; set; }
        public int? BatchId { get; set; }
    }
}
