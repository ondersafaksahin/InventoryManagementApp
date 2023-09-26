using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.ReservationDTOs
{
	public class ReservationCreateDTO
	{
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
    }
}
