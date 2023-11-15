using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.WareHouseDTOs
{
    public class WareHouseCreateDTO
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
        public string Name { get; set; }
        public string? Description { get; set; }
        public City? City { get; set; }
        public string? District { get; set; }

    }
}
