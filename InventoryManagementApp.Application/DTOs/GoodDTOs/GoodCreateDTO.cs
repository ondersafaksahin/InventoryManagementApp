
﻿using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.GoodDTOs
{
    public class GoodCreateDTO
    {
        public string Code { get; set; }
        public string? ModelCode { get; set; }
        public string Name { get; set; }
        public string? Picture { get; set; }
        public UnitType? StockingUnit { get; set; }
        public UnitType? ConsumptionUnit { get; set; }
        public byte? TaxPercentage { get; set; }
        public decimal? ListPrice { get; set; }
        public CurrencyCodes? ListCurrency { get; set; }
        public string? Barcode { get; set; }
        public float? GrossWeight { get; set; }
        public float? NetWeight { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? SubCategoryID { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }
        public BillOfMaterial? BillOfMaterial { get; set; }
        public int? BillOfMaterialID { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        
        public Status Status { get; set; } = Status.Active;
    }
}
