using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class PurchaseOrderDetails: IEntity<int>, IBaseEntity
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
        public UnitType? PurchaseUnit { get; set; }


        //Navigation Properties
        public PurchaseOrder PurchaseOrder { get; set; }
        public int PurchaseOrderID { get; set; }
        public Good Good { get; set; }
        public int GoodID { get; set; }
        public Warehouse DestinationWarehouse { get; set; }
        public int DestinationWarehouseID { get; set; }
        public Conversion? Conversion { get; set; }
        public int? ConversionId { get; set; }
        public List<GoodsReceiptDetail>? GoodsReceiptDetails { get; set; }

    }
}
