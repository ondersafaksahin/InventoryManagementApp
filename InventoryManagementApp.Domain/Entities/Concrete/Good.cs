using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Good:IBaseEntity,IEntity<int>
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string? ModelCode { get; set; }
        public string Name { get; set; }
        public string? Picture { get; set; }
		public UnitType? StockingUnit { get; set; }
        public UnitType? ConsumptionUnit { get; set; }
        public byte? TaxPercentage { get; set; }
        public decimal? ListPrice { get; set; }
        public CurrencyCodes? ListCurrency { get; set; }
        public string? Barcode { get; set; }
        public float? GrossWeight { get; set; }
        public float? NetWeight { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }
        

        //Navigation Properties
        public Brand? Brand { get; set; }
        public int? BrandId { get; set; }
        public Category? Category { get; set; }
        public int? CategoryID { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int? SubCategoryID { get; set; }
        public List<Supplier>? Suppliers { get; set; }
        

        //Product Part
        public BillOfMaterial? BillOfMaterial { get; set; }
        public int? BillOfMaterialID { get; set; }
        public List<ProductionOrder>? ProductionOrders { get; set; }
        public List<SalesOrderDetails>? SalesOrderDetails { get; set; }
        public List<Inventory>? Inventories { get; set; }
        public List<DeliveryDetail>? DeliveryDetails { get; set; }


        //Material Part
        public List<PurchaseOrderDetails>? PurchaseOrderDetails { get; set; }
        public List<GoodsReceiptDetail>? GoodsReceiptDetails { get; set; }

    }
}
