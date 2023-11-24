using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class SalesOrderDetails:IEntity<int>,IBaseEntity
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

        public decimal UnitPrice { get; set; }
        public CurrencyCodes PriceCurrency { get; set; }
        public float Quantity { get; set; }
        public UnitType? SalesUnit { get; set; }
        public float Discount { get; set; }

        //Navigation Properties

        public SalesOrder SalesOrder { get; set; }
        public int SalesOrderID { get; set; }
        public Good Good { get; set; }
        public int GoodID { get; set; }
        public Warehouse? SourceWarehouse { get; set; }
        public int? SourceWarehouseID { get; set; }
        public Conversion? Conversion { get; set; }
        public int? ConversionId { get; set; }
        public List<DeliveryDetail>? DeliveryDetails { get; set; }
    }
}
