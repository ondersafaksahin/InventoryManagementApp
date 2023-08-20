using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Conversion : IBaseEntity, IEntity<int>
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }
        public int ID { get; set; }

        //Navigation properties

        public virtual Good Good { get; set; }
        public int GoodID { get; set; }
        public float BaseGoodAmount { get; set; }
        public UnitType BaseUnit { get; set; }
        public float FinalGoodAmount { get; set; }
        public UnitType FinalUnit { get; set; }
        public List<Consumption>? Consumptions { get; set; }
        public List<SalesOrderDetails>? SalesOrderDetails { get; set; }
        public List<PurchaseOrderDetails>? PurchaseOrderDetails { get; set; }

    }
}
