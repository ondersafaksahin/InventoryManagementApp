﻿using InventoryManagementApp.Domain.Entities.Abstract.Classes;
using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Entities.Concrete
{
    public class Customer: IEntity<int>, IBaseEntity
    {
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
      
        public int ID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
