using InventoryManagementApp.Application.DTOs.SalesOrdesDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SalesOrderService
{
    public interface ISalesOrderService : IBaseService<SalesOrderCreateDTO, SalesOrderUpdateDTO, SalesOrderListDTO, SalesOrderDTO, SalesOrder, int>
    {
    }
}
