using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.ShelfDTOs
{
    public class ShelfUpdateDTO
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate = DateTime.Now;
        public Status Status { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }


        //IEntity
        public int ID { get; set; }

        //Additional Properties

        public string Name { get; set; }
        public string? Description { get; set; }

        //Navigation Properties

        public Warehouse? Warehouse { get; set; }
        public int WarehouseID { get; set; }
    }
}
