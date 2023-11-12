﻿using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.DTOs.WareHouseDTOs
{
    public class WareHouseUpdateDTO
    {
        //IBaseEntity
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }


        //IEntity
        public int ID { get; set; }


        //Additional Properties

        public string Name { get; set; }
        public string? Description { get; set; }
        public City? City { get; set; }
        public string? District { get; set; }


        //Navigation Properties
        public Shelf? newShelf { get; set; }
        public List<Shelf>? Shelves { get; set; }
    }
}
