using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Material:Good
    {
        public List<Supplier>? Suppliers { get; set; }
        public UnitType? PurchaseUnit { get; set; }
        public decimal? PurchasePrice { get; set; }
        public List<Shelf>? Shelves { get; set; }
    }
}
