﻿using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.ConversionVMs
{
    public class ConversionVM
    {
        public int ID { get; set; }
        public int GoodID { get; set; }
        public float BaseGoodAmount { get; set; }
        public UnitType BaseUnit { get; set; }
        public float FinalGoodAmount { get; set; }
        public UnitType FinalUnit { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
