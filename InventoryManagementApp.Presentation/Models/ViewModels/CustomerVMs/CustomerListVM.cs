﻿using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Presentation.Models.ViewModels.CustomerVMs
{
	public class CustomerListVM
	{
        public int ID { get; set; }
        public Status Status { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? WebPage { get; set; }
    }
}
