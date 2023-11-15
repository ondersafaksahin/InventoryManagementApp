using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
	public class Reservation : IBaseEntity, IEntity<int>
	{
		//IBaseEntity
		public string? CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public Status Status { get; set; }


		//IEntity
		public int ID { get; set; }
        public DateTime? EndDate { get; set; }
        public float Amount { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public List<Inventory> Inventories { get; set; }

    }
}
