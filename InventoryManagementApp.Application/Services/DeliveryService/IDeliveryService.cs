using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.DeliveryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.DeliveryService
{
    public interface IDeliveryService : IBaseService<DeliveryCreateDTO, DeliveryUpdateDTO, DeliveryListDTO, DeliveryDTO, Delivery, int>
    {
    }
}
