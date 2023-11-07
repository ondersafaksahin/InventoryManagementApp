using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.CustomerDTOs
{
    public class CustomerUpdateDTO
   {
        public int ID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? WebPage { get; set; }
        public Status Status { get; set; }
    }
}
