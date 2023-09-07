﻿using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.BatchDTOs
{
    public class BatchCreateDTO
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }

        //IEntity
        public int ID { get; set; }

        //Additional Properties

        public string BatchCode { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        //Navigation Properties

        public Good? Good { get; set; }
        public int? GoodID { get; set; }
        public ProductionOrder? ProductionOrder { get; set; }
        public int? ProductionOrderId { get; set; }
        public PurchaseOrderDetails? PurchaseOrderDetail { get; set; }
        public int? PurchaseOrderDetailId { get; set; }
    }
}
