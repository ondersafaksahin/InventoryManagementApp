using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class SalesOrder: IBaseEntity, IEntity<int>
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

        public decimal SalesOrderTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public CurrencyCodes Currency { get; set; }
        public string? SalesPersonnel { get; set; }

        //Navigation Properties
        public virtual List<SalesOrderDetails> SalesOrderDetails { get; set; }
        public Customer? Customer { get; set; }
        public int? CustomerID { get; set; }
    }
}
