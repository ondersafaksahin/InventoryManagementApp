using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.ModelDTOs
{
    public class ModelCreateDTO
    {
        public string ModelName { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
    }
}
