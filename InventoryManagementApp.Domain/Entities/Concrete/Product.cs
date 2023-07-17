using InventoryManagementApp.Domain.Entities.Abstract;
using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Product : IBaseEntity, IEntity<int>
    {
        //IBaseEntity
        public string? CreatedBy { get ; set ; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }


        //IEntity
        public int ID { get; set; }


        //Additional Properties
        public string Name { get; set; }
        public string? Picture { get; set; }
        public float StockAmount { get; set; }
        public float? ReservedStock { get; set; }
        public UnitType? StockingUnit { get; set; }
        public UnitType? PurchaseUnit { get; set; }
        public UnitType? SalesUnit { get; set; }
        public UnitType? ConsumptionUnit { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public float? MinStock { get; set; }
        public byte TaxPercentage { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string? Barcode { get; set; }
        public float? GrossWeight { get; set; }
        public float? NetWeight { get; set; }


        //Navigation Properties

        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int? SubCategoryID { get; set; }
        public List<Batch>? Batches { get; set; }

    }
}
