using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.DeliveryDetailDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.DeliveryDetailService
{
    public interface IDeliveryDetailService : IBaseService<DeliveryDetailDTO, DeliveryDetailUpdateDTO, DeliveryDetailListDTO, DeliveryDetailDTO, DeliveryDetail, int>
    {
    }
}
