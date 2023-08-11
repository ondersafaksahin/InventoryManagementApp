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

        public virtual Good BaseMaterial { get; set; }
        public int BaseMaterialID { get; set; }
        public float BaseMaterialAmount { get; set; }
        public UnitType BaseUnit { get; set; }
        public virtual Good FinalMaterial { get; set; }
        public int FinalMaterialID { get; set; }
        public float FinalMaterialAmount { get; set; }
        public UnitType FinalUnit { get; set; }

    }
}
