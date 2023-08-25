using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Customer: ITrader
    {
      
        public int ID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }


        //ITrader

        public string? Name { get; set; }
        public string? Contact { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? WebPage { get; set; }

        //Additional props
        public List<SalesOrder>? SalesOrders { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
