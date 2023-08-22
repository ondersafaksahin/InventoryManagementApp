using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ProductionOrderService
{
	public interface IProductionOrderService:IBaseService<ProductionOrderCreateDTO, ProductionOrderUpdateDTO, ProductionOrderListDTO, ProductionOrderDTO, ProductionOrder,int>
	{
	}
}
