﻿using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.GoodDTOs
{
    public class GoodListDTO
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float StockAmount { get; set; }
        public float? ReservedStock { get; set; }
        public float? MinStock { get; set; }
        public decimal? ListPrice { get; set; }
        public string? Barcode { get; set; }
       

        public Status Status { get; set; }
    }
}
