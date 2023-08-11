using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Product : Good
    {
        public BillOfMaterial BillOfMaterial { get; set; }
        public int BillOfMaterialID { get; set; }
        public List<ProductionOrder> ProductionOrders { get; set; }
    }
}
