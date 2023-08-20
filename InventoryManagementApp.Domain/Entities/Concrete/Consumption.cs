using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Consumption: IBaseEntity, IEntity<int>
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
        public float AmountUsed { get; set; }
        public UnitType UnitofConsumption { get; set; }

        //Navigation Properties
        
        public virtual Good UsedMaterial { get; set; }
        public int GoodID { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
        public int ProductionOrderId { get; set; }

        public Conversion? Conversion { get; set; }
        public int? ConversionId { get; set; }

    }
}
