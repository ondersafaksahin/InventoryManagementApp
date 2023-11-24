using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class DeliveryDetail : IBaseEntity, IEntity<int>
    {
        //IBaseEntity
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }


        //IEntity
        public int ID { get; set; }

        //Additional Properties
        public int Amount { get; set; }

        //Navigation Properties
        public Delivery Delivery { get; set; }
        public int DeliveryID { get; set; }
        public Good Good { get; set; }
        public int GoodID { get; set; }
        public SalesOrderDetails SalesOrderDetails { get; set; }
        public int SalesOrderDetailsID { get; set; }
        public Batch? Batch { get; set; }
        public int? BatchID { get; set; }

    }
}
