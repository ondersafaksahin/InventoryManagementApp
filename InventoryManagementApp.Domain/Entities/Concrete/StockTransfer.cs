using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class StockTransfer: IBaseEntity, IEntity<int>
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
        public float Amount { get; set; }
        public string? Description { get; set; }

        //Navigation Properties
        public virtual Good Good { get; set; }
        public int GoodId { get; set; }
        public Warehouse? SourceWarehouse { get; set; }
        public int? SourceWarehouseID { get; set; }
        public Warehouse? DestinationWarehouse { get; set; }
        public int? DestinationWarehouseID { get; set; }
        public Batch? Batch { get; set; }
        public int? BatchId { get; set; }
    }
}
