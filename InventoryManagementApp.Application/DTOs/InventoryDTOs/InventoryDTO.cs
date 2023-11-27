using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.InventoryDTOs
{
    public class InventoryDTO
    {
        public int ID { get; set; }

        //IBaseEntity
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }

        //Additional Properties
        public float Amount { get; set; }
        public int GoodId { get; set; }
        public int? WarehouseId { get; set; }
        public int? BatchId { get; set; }
    }
}
