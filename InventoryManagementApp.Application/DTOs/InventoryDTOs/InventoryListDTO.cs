using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.InventoryDTOs
{
    public class InventoryListDTO
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

        //Navigation Properties
        public virtual Good Good { get; set; }
        public int GoodId { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public int? WarehouseId { get; set; }
        public Batch? Batch { get; set; }
        public int? BatchId { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
