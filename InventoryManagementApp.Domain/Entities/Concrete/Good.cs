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
        public string Name { get; set; }
        public string? Picture { get; set; }
        public float StockAmount { get; set; }
        public float? ReservedStock { get; set; }
        public UnitType? StockingUnit { get; set; }
        public UnitType? ConsumptionUnit { get; set; }
        public Brand? Brand { get; set; }
        public int? BrandId { get; set; }
        public Model? Model { get; set; }
        public int? ModelId { get; set; }
        public float? MinStock { get; set; }
        public byte? TaxPercentage { get; set; }
        public decimal? ListPrice { get; set; }
        public string? Barcode { get; set; }
        public float? GrossWeight { get; set; }
        public float? NetWeight { get; set; }

        public Category? Category { get; set; }
        public SubCategory? SubCategory { get; set; }
        public List<Batch>? Batches { get; set; }
        public List<Warehouse>? Warehouses { get; set; }
        public List<Shelf>? Shelves { get; set; }
        public List<Supplier>? Suppliers { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }


        //Product Part
        public BillOfMaterial? BillOfMaterial { get; set; }
        public int? BillOfMaterialID { get; set; }
        public List<ProductionOrder>? ProductionOrders { get; set; }
        public List<SalesOrderDetails>? SalesOrderDetails { get; set; }


        //Material Part
        public List<PurchaseOrderDetails>? PurchaseOrderDetails { get; set; }

    }
}
