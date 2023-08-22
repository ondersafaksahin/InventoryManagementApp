using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Abstract.Interfaces
{
    public interface IUser: IBaseEntity
    {
        public string? Picture { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Job { get; set; }
        public string? Department { get; set; }
        public string? Title { get; set; }
        public Gender? Gender { get; set; }
    }
}
