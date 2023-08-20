using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class BillOfMaterialDetails : IEntity<int>, IBaseEntity
    {
        //IBaseEntity
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }


        //IEntity
        public int ID { get; set; }
        public int GoodID { get; set; }
        public Good MaterialUsed { get; set; }
        public float ConsumptionAmount { get; set; }
        public UnitType UnitOfComsumption { get; set; }
        public BillOfMaterial BillOfMaterial { get; set; }
        public int BillOfMaterialId { get; set; }

        //public List<(int goodID, float consumption, UnitType unitType)>? Consumptions { get; set; }
    }
}
