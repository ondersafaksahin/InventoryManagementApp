using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.InventoryDTOs
{
    public class InventoryUpdateDTO
    {
        public int ID { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }

        //Additional Properties
        public float Amount { get; set; }
        public float ReorderLevel { get; set; }

        //Navigation Properties
        public virtual Warehouse? Warehouse { get; set; }
        public int? WarehouseId { get; set; }
        public Batch? Batch { get; set; }
        public int? BatchId { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
