using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class PurchaseOrder: IBaseEntity, IEntity<int>
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

        public decimal PurchaseOrderTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public CurrencyCodes Currency { get; set; }

        //Navigation Properties
        public virtual List<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierID { get; set; }
    }
}
