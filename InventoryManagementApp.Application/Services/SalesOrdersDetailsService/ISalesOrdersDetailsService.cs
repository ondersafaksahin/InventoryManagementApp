using InventoryManagementApp.Application.DTOs.SalesOrdesDetailsDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SalesOrdersDetailsService
{
    public interface ISalesOrdersDetailsService : IBaseService<SalesOrdersDetailsCreateDTO, SalesOrdersDetailsUpdateDTO, SalesOrdersDetailsListDTO, SalesOrdersDetailsDTO, SalesOrderDetails, int>
    {
    }
}
