using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.PurchaseOrderService
{
    public interface IPurchaseOrderService:IBaseService<PurchaseOrderCreateDTO, PurchaseOrderUpdateDTO, PurchaseOrderListDTO, PurchaseOrderDTO, PurchaseOrder, int>
    {
    }
}
