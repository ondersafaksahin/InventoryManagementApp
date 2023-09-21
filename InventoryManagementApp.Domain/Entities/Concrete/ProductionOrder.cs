using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class ProductionOrder:IBaseEntity,IEntity<int>
    {
        public int ID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }

        //Additional properties

        public float Amount { get; set; }
        public UnitType UnitType { get; set; }


        //Navigation props
        public Good Product { get; set; }
        public int GoodId { get; set; }
        public Batch? Batch { get; set; }
        public int BatchId { get; set; }

        //Bu üretimin batch numarasını, üretimin productının batch listesine add yapılması gerekiyor

        //public List<Consumption>? Consumptions { get; set; }
    }
}
