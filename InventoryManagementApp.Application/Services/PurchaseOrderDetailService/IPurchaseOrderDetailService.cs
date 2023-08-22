using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.PurchaseOrderDetailService
{
    public interface IPurchaseOrderDetailService:IBaseService<PurchaseOrderDetailCreateDTO, PurchaseOrderDetailUpdateDTO, PurchaseOrderDetailListDTO, PurchaseOrderDetailDTO, PurchaseOrderDetails, int>
    {
    }
}
