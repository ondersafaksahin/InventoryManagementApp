using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Abstract.Interfaces
{
    public interface ITrader: IEntity<int>, IBaseEntity
    {
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? WebPage { get; set; }
    }
}
