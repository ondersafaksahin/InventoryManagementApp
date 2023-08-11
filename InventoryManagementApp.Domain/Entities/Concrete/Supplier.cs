using InventoryManagementApp.Domain.Entities.Abstract.Classes;
using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
	public class Supplier:Company
	{
        public List<Good>? PurchasedGoods { get; set; }
        public List<PurchaseOrder>? PurchaseOrders { get; set; }

        //Risk score to be added
    }
}
